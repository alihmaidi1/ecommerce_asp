using ecommerce.admin.Features.Password.Models;
using ecommerce.Domain.Entities.Identity;
using ecommerce.Domain.Enum;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
using ecommerce.infrutructure.ExtensionMethod;
using ecommerce.service.UserService;
using ecommerce_shared.Enums;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Jwt;
using Repositories.Jwt.Factory;
using System.Security.Claims;

namespace ecommerce.admin.Features.Password.Commands
{
    public class PasswordHandlers : OperationResult,
        IRequestHandler<ForgetPasswordCommand, JsonResult>,
        IRequestHandler<CheckCodeCommand, JsonResult>

    {
        private IAccountService AccountService;
        private UserManager<Account> UserManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISchemaFactory SchemaFactory;

        private IJwtRepository JwtRepository;
        private ApplicationDbContext Context;



        public PasswordHandlers(ApplicationDbContext Context,IHttpContextAccessor _httpContextAccessor,UserManager<Account> UserManager, ISchemaFactory SchemaFactory,IAccountService AccountService) { 
        
            this._httpContextAccessor = _httpContextAccessor;
            this.AccountService = AccountService;
            this.Context = Context;
            this.JwtRepository = SchemaFactory.CreateJwt(JwtSchema.Main);
            this.UserManager = UserManager; 
            this.SchemaFactory=SchemaFactory;
        }
        public async Task<JsonResult> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            Account Account = Context.FindAccountByEmailAndRole(request.Email, RoleEnum.SuperAdmin.ToString());
            await AccountService.ResetCode(Account);
            string Token = SchemaFactory.CreateJwt(JwtSchema.ResetPassword).GetToken(Account);
            return Success(new {Token}, "The Email Was Sended Successfully");
        
        }

        public async Task<JsonResult> Handle(CheckCodeCommand request, CancellationToken cancellationToken)
        {
            var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x=>x.Type.Equals(ClaimTypes.NameIdentifier)).Value;
            Account Account = await UserManager.FindByIdAsync(Id);
            TokenDto TokenInfo = await JwtRepository.GetTokensInfo(Account);            
            return Success(TokenInfo,"The Code is Correct");

        }
    }
}
