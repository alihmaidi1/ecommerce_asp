using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce.Domain.Abstract;
using ecommerce.Domain.SharedResources;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.Admin.Auth.Commands;
using ecommerce.service.UserService;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Repositories.Admin.Store;
using Repositories.Jwt;

namespace ecommerce.admin.Features.Auth.Commands.Handlers
{
    public class AuthCommandHandlers : OperationResult,
        IRequestHandler<LoginAdminCommand, JsonResult>
    {

        public readonly IAccountService AccountService;
        public IStringLocalizer<SharedResource> stringLocalizer;
        public IJwtRepository jwtRepository;

        public AuthCommandHandlers(
               IStringLocalizer<SharedResource> stringLocalizer,
               IAccountService AccountService,
                IJwtRepository jwtRepository
                ) 
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
