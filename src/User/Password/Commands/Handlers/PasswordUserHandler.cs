using ecommerce.Domain.Entities.Identity;
using ecommerce.Dto.Base;
using ecommerce.models.Users.Auth.Commands;
using ecommerce.models.Users.Password.Commands;
using ecommerce.service.UserService;
using ecommerce_shared.Enums;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Jwt;
using Repositories.Jwt.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Password.Commands.Handlers
{
    public class PasswordUserHandler : OperationResult,
        IRequestHandler<ForgetPasswordCommand, JsonResult>,
        IRequestHandler<CheckCodeCommand, JsonResult>


    {

        public IAccountService AccountService;
        public UserManager<Account> UserManager;
        public ISchemaFactory SchemaFactory;
        public IHttpContextAccessor HttpContextAccessor;
        public IJwtRepository jwtRepository;
        public PasswordUserHandler(ISchemaFactory SchemaFactory,IHttpContextAccessor HttpContextAccessor, IAccountService AccountService,UserManager<Account> UserManager)
        {
            this.HttpContextAccessor = HttpContextAccessor;
            this.SchemaFactory = SchemaFactory;
            this.jwtRepository = SchemaFactory.CreateJwt(JwtSchema.User);
            this.UserManager = UserManager;
            this.AccountService = AccountService;   


        }

        public async Task<JsonResult> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            await AccountService.ResetCode(request.Email);
            Account Account = await UserManager.FindByEmailAsync(request.Email);
            string Token = SchemaFactory.CreateJwt(JwtSchema.ResetPassword).GetToken(Account);
            return Success(new { Token }, "The Email Was Sended Successfully");


        }

        public async Task<JsonResult> Handle(CheckCodeCommand request, CancellationToken cancellationToken)
        {
            var Id = HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;
            Account Account = await UserManager.FindByIdAsync(Id);
            TokenDto TokenInfo = await jwtRepository.GetTokensInfo(Account);
            return Success(TokenInfo, "The Code is Correct");

        }
    }
}
