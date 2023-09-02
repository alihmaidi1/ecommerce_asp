using AutoMapper;
using ecommerce.Domain.Entities.Identity;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.User.Auth.Command;
using ecommerce.models.Users.Auth.Commands;
using ecommerce.service.UserService;
using ecommerce_shared.Enums;
using ecommerce_shared.OperationResult;
using ecommerce_shared.Redis;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Jwt;
using Repositories.Jwt.Factory;
using Repositories.User.Store;

namespace ecommerce.user.Auth.Commands.Handlers
{
    internal class AuthUserCommandHandlers : OperationResult,

        IRequestHandler<AddUserCommand, JsonResult>,
    IRequestHandler<ConfirmAccountCommand, JsonResult>

    //IRequestHandler<LoginUserCommand, JsonResult>,
    //IRequestHandler<LogoutUserCommand, JsonResult>


    {

        public readonly ICacheRepository CacheRepository;
        public readonly IAccountService AccountService;
        public IJwtRepository jwtRepository;

        public IUserService UserService;

        public IMapper mapper;


        public AuthUserCommandHandlers(
            IAccountService AccountService,
            ICacheRepository CacheRepository,
            ISchemaFactory SchemaFactory,
            IUserService UserService,
            IMapper mapper
            )

        {
            this.AccountService = AccountService;
            jwtRepository = SchemaFactory.CreateJwt(JwtSchema.Main);
            this.CacheRepository = CacheRepository;
            this.UserService = UserService;
            this.mapper=mapper; 
        }

        public async Task<JsonResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await UserService.CreateUser(request);
            await AccountService.ResetCode(request.Email);
            return Created(true, "Account Created Please Check Your Email To Confirm Your Account");

        }

        public async Task<JsonResult> Handle(ConfirmAccountCommand request, CancellationToken cancellationToken)
        {

            User User = await UserService.ConfirmAccount(request.Email, request.Code);
            TokenDto TokenInfo = await jwtRepository.GetTokensInfo(User.Account);
            UserWithToken UserWithToken = UserStoreService.Query.CreateUserResponse(User, TokenInfo);
            return Success(UserWithToken, "Your Account Was Confirmed Successfully");

        }

        //public async Task<JsonResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        //{

        //    Account Account = await AccountService.SignInAccountAsync(request.UserNameOrEmail, request.Password);
        //    TokenDto TokenInfo = await jwtRepository.GetTokensInfo(Account);
        //    UserWithToken result = UserStoreService.Query.CreateUserResponse(Account.User, TokenInfo);
        //    return Success(result, "You Are Login Successfully");

        //}

        //public async Task<JsonResult> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        //{

        //    CacheRepository.RemoveData("Token:" + request.Token);
        //    return Success("You Are Logout Successfully");

        //}

    }
}
