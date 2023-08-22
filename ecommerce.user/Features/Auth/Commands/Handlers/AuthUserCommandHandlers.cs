using AutoMapper;
using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce.Domain.SharedResources;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce.infrutructure;
using ecommerce.user.Features.Auth.Commands.Models;
using ecommerce_shared.Exceptions;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.Repository.Concrete;
using ecommerce_shared.Repository.interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Repositories.User.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Handlers
{
    internal class AuthUserCommandHandlers : OperationResult,
        IRequestHandler<AddUserCommand, JsonResult>,
        IRequestHandler<LoginUserCommand, JsonResult>

    {

        public IStringLocalizer<SharedResource> _StringLocalizer;
        public readonly ApplicationDbContext DbContext;
        public readonly IMapper mapper;
        public readonly UserManager<Account> userManager;

        public IJwtRepository jwtRepository;

        public AuthUserCommandHandlers(
            IStringLocalizer<SharedResource> _StringLocalizer,
            ApplicationDbContext DbContext,
            UserManager<Account> UserManager,
            IMapper mapper,
            IJwtRepository jwtRepository
            ) :base(_StringLocalizer)
            
        {
            this._StringLocalizer= _StringLocalizer;    
            this.DbContext=DbContext;
            this.userManager = UserManager;
            this.mapper= mapper;    
            this.jwtRepository= jwtRepository;
        }

        public async Task<JsonResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var Account =mapper.Map<Account>(request);
            var Accountresult=await this.userManager.CreateAsync(Account, request.Password);
            this.DbContext.SaveChanges();
            if (!Accountresult.Succeeded)
            {
                   throw new CanotCreateAccountException(Accountresult.Errors);
            }
            var User = DbContext.Users.CreateProxy();
            mapper.Map(request,User,opts=>opts.AfterMap((src,desc)=>desc.AccountId=Account.Id));            
            this.DbContext.Users.Add(User);                       
            DbContext.SaveChanges();                        
            TokenDto TokenInfo =await jwtRepository.GetTokens(Account);
            UserWithToken result = UserStoreService.Query.CreateUserResponse(User, TokenInfo);
            return Created<UserWithToken>(result,"The User Was Created SuccessFully");
              


        }

        public Task<JsonResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
