using ecommerce.Domain.Entities.Identity;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
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
        public ApplicationDbContext Context;
        public PasswordUserHandler(ApplicationDbContext Context,ISchemaFactory SchemaFactory,IHttpContextAccessor HttpContextAccessor, IAccountService AccountService,UserManager<Account> UserManager)
        {
            this.HttpContextAccessor = HttpContextAccessor;
            this.SchemaFactory = SchemaFactory;
            this.jwtRepository = SchemaFactory.CreateJwt(JwtSchema.User);
            this.UserManager = UserManager;
            this.AccountService = AccountService;   
            this.Context= Context;


        }

        public async Task<JsonResult> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            User ?User = Context.Accounts
                                .OfType<User>()
                                .FirstOrDefault(x=>x.Email.Equals(request.Email)&&x.ProviderType==ProviderAuthentication.Local                                        );
            await AccountService.ResetCode(User);
            string Token = SchemaFactory.CreateJwt(JwtSchema.ResetPassword).GetToken(User);
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
