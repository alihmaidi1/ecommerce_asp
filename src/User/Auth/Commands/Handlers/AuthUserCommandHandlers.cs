using AutoMapper;
using ecommerce.Domain.Entities.Identity;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce.models.Users.Auth.Commands;
using ecommerce.service.UserService;
using ecommerce_shared.Enums;
using ecommerce_shared.OperationResult;
using ecommerce_shared.Redis;
using ecommerce_shared.Services.Authentication;
using ecommerce_shared.Services.Authentication.Factory;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Jwt;
using Repositories.Jwt.Factory;
using Repositories.User.Store;

namespace ecommerce.user.Auth.Commands.Handlers
{
    internal class AuthUserCommandHandlers : OperationResult,

        IRequestHandler<AddUserCommand, JsonResult>,
        IRequestHandler<ConfirmAccountCommand, JsonResult>,
        IRequestHandler<LoginUserCommand, JsonResult>,
        IRequestHandler<LogoutUserCommand, JsonResult>,
        IRequestHandler<AuthenticateWithGoogleCommand, JsonResult>,
        IRequestHandler<AuthenticateWithGithubCommand, JsonResult>




    {

        public readonly ICacheRepository CacheRepository;
        public readonly IAccountService AccountService;
        public IJwtRepository jwtRepository;
        public IHttpContextAccessor httpContextAccessor;
        public IAuthenticationFactory AuthenticationFactory;

        public IUserService UserService;

        public IMapper mapper;


        public AuthUserCommandHandlers(
            IAccountService AccountService,
            ICacheRepository CacheRepository,
            ISchemaFactory SchemaFactory,
            IUserService UserService,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IAuthenticationFactory AuthenticationFactory
            )

        {
            this.AccountService = AccountService;
            jwtRepository = SchemaFactory.CreateJwt(JwtSchema.User);
            this.CacheRepository = CacheRepository;
            this.UserService = UserService;
            this.httpContextAccessor= httpContextAccessor;
            this.mapper=mapper; 
            this.AuthenticationFactory=AuthenticationFactory;
        
        }

        public async Task<JsonResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            
            User User=await UserService.CreateUser(request);
            
            BackgroundJob.Enqueue(() => AccountService.SendConfirmCode(User.Id,User.Email));
            return Created(true, "Account Created Please Check Your Email To Confirm Your Account");

        }

        public async Task<JsonResult> Handle(ConfirmAccountCommand request, CancellationToken cancellationToken)
        {

            User User = await UserService.ConfirmAccount(request.Email, request.Code);
            TokenDto TokenInfo = await jwtRepository.GetTokensInfo(User);
            UserWithToken UserWithToken = UserStoreService.Query.CreateUserResponse(User, TokenInfo);
            return Success(UserWithToken, "Your Account Was Confirmed Successfully");

        }


        public async Task<JsonResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            User User =  await UserService.SigninUser(request.UserName, request.Password);
            TokenDto TokenInfo = await jwtRepository.GetTokensInfo(User);
            UserWithToken result = UserStoreService.Query.CreateUserResponse(User, TokenInfo);
            return Success(result, "You Are Login Successfully");

        }

        public async Task<JsonResult> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {

            string Token = httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
            CacheRepository.RemoveData("Token:" + Token);
            return Success("You Are Logout Successfully");

        }

        public async Task<JsonResult> Handle(AuthenticateWithGoogleCommand request, CancellationToken cancellationToken)
        {
            var ApiResponse = await AuthenticationFactory.CreateAuthenticationService(ProviderAuthentication.Google).GetUserInfo(request.Token);
            User User=await UserService.AuthenticateExternal(ApiResponse,ProviderAuthentication.Google);
            TokenDto TokenInfo =await jwtRepository.GetTokensInfo(User);
            UserWithToken UserWithToken = UserStoreService.Query.CreateUserResponse(User, TokenInfo);
            return Success(UserWithToken, "You Are Login Successfully");

        }

        public async Task<JsonResult> Handle(AuthenticateWithGithubCommand request, CancellationToken cancellationToken)
        {

            var ApiResponse = await AuthenticationFactory.CreateAuthenticationService(ProviderAuthentication.Git).GetUserInfo(request.Token);
            User User = await UserService.AuthenticateExternal(ApiResponse, ProviderAuthentication.Git);
            TokenDto TokenInfo = await jwtRepository.GetTokensInfo(User);
            UserWithToken UserWithToken = UserStoreService.Query.CreateUserResponse(User, TokenInfo);
            return Success(UserWithToken, "You Are Login Successfully");


        }
    }
}
