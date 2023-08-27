using AutoMapper;
using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce.Domain.SharedResources;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce.infrutructure;
using ecommerce.infrutructure.Services.Interfaces;
using ecommerce.service.UserService;
using ecommerce.user.Features.Auth.Commands.Models;
using ecommerce_shared.OperationResult;
using ecommerce_shared.Redis;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Repositories.Jwt;
using Repositories.User.Store;

namespace ecommerce.user.Features.Auth.Commands.Handlers
{
    internal class AuthUserCommandHandlers : OperationResult,
        IRequestHandler<AddUserCommand, JsonResult>,
        IRequestHandler<LoginUserCommand, JsonResult>,
        IRequestHandler<LogoutUserCommand, JsonResult>


    {

        public IStringLocalizer<SharedResource> _StringLocalizer;
        public readonly ICacheRepository CacheRepository;
        public readonly ApplicationDbContext DbContext;
        public readonly IMapper mapper;
        public readonly UserManager<Account> userManager;
        public readonly IAccountService AccountService;
        public IJwtRepository jwtRepository;
        

        public AuthUserCommandHandlers(
            IStringLocalizer<SharedResource> _StringLocalizer,
            ApplicationDbContext DbContext,
            IAccountService AccountService,
            ICacheRepository CacheRepository,
            UserManager<Account> UserManager,
            IMapper mapper,
            IJwtRepository jwtRepository
            ) 
            
        {
            this._StringLocalizer= _StringLocalizer;    
            this.DbContext=DbContext;
            this.userManager = UserManager;
            this.mapper= mapper;    
            this.AccountService= AccountService;
            this.jwtRepository= jwtRepository;
            this.CacheRepository = CacheRepository;
        }

        public async Task<JsonResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var Account =mapper.Map<Account>(request);
            await AccountService.CreateAccountAsync(Account,request.Password);
                        
            
            var User = DbContext.Users.CreateProxy();
            mapper.Map(request,User,opts=>opts.AfterMap((src,desc)=>desc.AccountId=Account.Id));            
            this.DbContext.Users.Add(User);                       
            DbContext.SaveChanges();      
            


            TokenDto TokenInfo =await jwtRepository.GetTokens(Account);
            UserWithToken result = UserStoreService.Query.CreateUserResponse(User, TokenInfo);
            return Created<UserWithToken>(result,"The User Was Created SuccessFully");
              


        }

        public async Task<JsonResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            Account Account = await AccountService.SignInAccountAsync(request.UserNameOrEmail,request.Password);
            TokenDto TokenInfo =await jwtRepository.GetTokens(Account);
            UserWithToken result = UserStoreService.Query.CreateUserResponse(Account.User, TokenInfo);
            return Success(result,"You Are Login Successfully");

        }

        public async  Task<JsonResult> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {

            CacheRepository.RemoveData("Token:"+request.Token);
            return Success("You Are Logout Successfully");
        
        }

    }
}
