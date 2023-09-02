using ecommerce.admin.Features.Pages.Commands.Models;
using ecommerce.admin.Features.Password.Models;
using ecommerce.Domain.Entities.Identity;
using ecommerce.Dto.Base;
using ecommerce.service.UserService;
using ecommerce_shared.Enums;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Account;
using Repositories.Jwt;
using Repositories.Jwt.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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


        public PasswordHandlers(IHttpContextAccessor _httpContextAccessor,UserManager<Account> UserManager, ISchemaFactory SchemaFactory,IAccountService AccountService) { 
        
            this._httpContextAccessor = _httpContextAccessor;
            this.AccountService = AccountService;
            this.JwtRepository = SchemaFactory.CreateJwt(JwtSchema.Main);
            this.UserManager = UserManager; 
            this.SchemaFactory=SchemaFactory;
        }
        public async Task<JsonResult> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {

            await AccountService.ResetCode(request.Email);
            Account Account=await UserManager.FindByEmailAsync(request.Email);
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
