//using AutoMapper;
//using ecommerce.Domain.Entities.Identity;
//using ecommerce.infrutructure;
//using ecommerce.models.Users.Auth.Commands;
//using ecommerce_shared.Constant;
//using ecommerce_shared.Enums;
//using ecommerce_shared.File;
//using ecommerce_shared.File.S3;
//using ecommerce_shared.Helper;
//using ecommerce_shared.Services.Authentication.ResponseAuth;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Repositories.User;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.service.UserService
//{
//    public class UserService:IUserService
//    {

//        public readonly IMapper mapper;
//        public ApplicationDbContext Context;
//        public UserManager<Account> UserManager;

//        public readonly IAccountService AccountService;
//        public readonly IUserRepository UserRepository;
//        public readonly IStorageService StorageService;

//        public UserService(IStorageService StorageService,IUserRepository UserRepository,UserManager<Account> UserManager,IMapper mapper, IAccountService AccountService, ApplicationDbContext Context)
//        {

//            this.mapper = mapper;
//            this.Context = Context;
//            this.UserRepository = UserRepository;   
//            this.UserManager = UserManager;
//            this.AccountService = AccountService;
//            this.StorageService= StorageService;

//        }

//        public async Task<User> CreateUser(AddUserCommand request)
//        {
//            var User = mapper.Map<User>(request);
//            if(request.Logo != null)
//            {

//                ImageResponse image = await StorageService.OptimizeFile(request.Logo, FolderName.User);
//                User.Logo = image.Url;
//                User.hash = image.hash;
//                User.resizedLogo = image.resized;


//            }
//            User = await AccountService.CreateAccountAsync(User, request.Password) as User;
//            return User;
        
//        }

<<<<<<< HEAD
//        public async Task<User> ConfirmAccount(string Email, string Code)
//        {
//            var Account = Context.Users.FirstOrDefault(x=>x.Email.Equals(Email)&&x.ProviderType==ProviderAuthentication.Local);
//            Account.ConfirmCode.Equals(Code).ThrowIfFalse("Your Code Is Not Correct");
//            Account.EmailConfirmed = true;
//            await UserManager.UpdateAsync(Account);
//            return Account as User;
=======
        public async Task<User> ConfirmAccount(string Email, string Code)
        {
            var Account = Context.Users.FirstOrDefault(x=>x.Email.Equals(Email)&&x.ProviderType==ProviderAuthentication.Local);
            Account.ConfirmCode?.Equals(Code).ThrowIfFalse("Your Code Is Not Correct");
            Account.EmailConfirmed = true;
            await UserManager.UpdateAsync(Account);
            return Account as User;
>>>>>>> ed

//        }

//        public async Task<User> SigninUser(string UserNameOrEmail,string Passowrd)
//        {


//            Account Account = await AccountService.SignInAccountAsync(UserNameOrEmail, Passowrd);
//            Account.EmailConfirmed.ThrowIfFalse("Your Email Is Not Confirmed");
//            return Account as User;
//        }


//        public async Task<User> AuthenticateExternal(Response ApiRespones,ProviderAuthentication provider)
//        {
//            User User = await UserRepository.GetUserByProviderId(ApiRespones.sub,provider);
//            if(User == null)
//            {
//                User= await UserRepository.CreateExternalUser(ApiRespones, provider);

//            }
//            return User;


//        }




//    }
//}
