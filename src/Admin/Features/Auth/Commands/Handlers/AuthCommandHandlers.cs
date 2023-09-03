using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce.Domain.Entities.Identity;
using ecommerce.Domain.SharedResources;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.Admin.Auth.Commands;
using ecommerce.service.UserService;
using ecommerce_shared.Enums;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Repositories.Admin.Store;
using Repositories.Jwt;
using Repositories.Jwt.Factory;

namespace ecommerce.admin.Features.Auth.Commands.Handlers
{
    public class AuthCommandHandlers : OperationResult,
        IRequestHandler<LoginAdminCommand, JsonResult>,
        IRequestHandler<LogoutCommand, JsonResult>

    {

        public readonly IAccountService AccountService;
        public IStringLocalizer<SharedResource> stringLocalizer;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IJwtRepository jwtRepository;

        public AuthCommandHandlers(
               IStringLocalizer<SharedResource> stringLocalizer,
               IAccountService AccountService,
                ISchemaFactory SchemaFactory,
                IHttpContextAccessor _httpContextAccessor
                ) 
        {

            this._httpContextAccessor = _httpContextAccessor;
            this.AccountService = AccountService;
            this.jwtRepository = SchemaFactory.CreateJwt(JwtSchema.Main);
            

        }

        public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
        {

            Account Account = await AccountService.SignInAccountAsync(request.Username, request.Password);
            TokenDto TokenInfo = await jwtRepository.GetTokensInfo(Account);
            AdminWithToken result = AdminStoreRepository.Dto.AdminWithToken(Account,TokenInfo);
            return Success(result, "You Are Login Successfully");




        }

        public async Task<JsonResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {

            string Token = _httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
            bool status=await AccountService.Logout(Token);
            return Success(status,"You Are Logout Successfully");
        }
    }
}
