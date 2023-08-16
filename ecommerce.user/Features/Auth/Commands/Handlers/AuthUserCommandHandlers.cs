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
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Handlers
{
    internal class AuthUserCommandHandlers : OperationResult,
        IRequestHandler<AddUserCommand, OperationResultBase<UserWithToken>>,
        IRequestHandler<LoginUserCommand, OperationResultBase<string>>

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

        public async Task<OperationResultBase<UserWithToken>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var Account =mapper.Map<Account>(request);
            var Accountresult=await this.userManager.CreateAsync(Account, request.Password);
            this.DbContext.SaveChanges();
            if (!Accountresult.Succeeded)
            {
                   throw new CanotCreateAccountException(Accountresult.Errors);
            }
            var User = mapper.Map<User>(request,opts=>opts.AfterMap((src,desc)=>desc.AccountId=Account.Id));            
            this.DbContext.Users.Add(User);
            this.DbContext.SaveChanges();
            TokenDto TokenInfo=jwtRepository.GetTokens(Account);
            UserWithToken result = new UserWithToken()
            {

                Id=User.Id,
                Name=User.Name,
                UserName=User.Account.UserName,
                City=User.City,
                Email=User.Account.Email,
                IsBlocked=User.IsBlocked,
                Point=User.Point,   
                TokenInfo=TokenInfo
                

            };
            return Created<UserWithToken>(result,"The User Was Created SuccessFully");
              


        }

        public Task<OperationResultBase<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
