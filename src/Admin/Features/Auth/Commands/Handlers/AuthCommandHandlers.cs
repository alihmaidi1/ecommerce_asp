using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce.Domain.Abstract;
using ecommerce.Domain.SharedResources;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.Admin.Auth.Commands;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce.service.UserService;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.Repository.Concrete;
using ecommerce_shared.Repository.interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Repositories.Admin.Store;
using Repositories.User.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Auth.Commands.Handlers
{
    public class AuthCommandHandlers : OperationResult,
        IRequestHandler<LoginAdminCommand, JsonResult>
    {

        public readonly IAccountService AccountService;

        public IJwtRepository jwtRepository;

        public AuthCommandHandlers(IStringLocalizer<SharedResource> stringLocalizer
            , IAccountService AccountService,
            IJwtRepository jwtRepository) : base(stringLocalizer)
        {

            this.AccountService = AccountService;
            this.jwtRepository = jwtRepository;

        }

        public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
        {

            Account Account = await AccountService.SignInAccountAsync(request.UsernameOrEmail, request.Password);
            TokenDto TokenInfo = await jwtRepository.GetTokens(Account);
            AdminWithToken result = AdminStoreRepository.Dto.AdminWithToken(Account,TokenInfo);
            return Success(result, "You Are Login Successfully");




        }
    }
}
