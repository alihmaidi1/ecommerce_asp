<<<<<<< HEAD
﻿using ecommerce_shared.Exceptions;
=======
﻿
using ecommerce_shared.Exceptions;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
using Microsoft.AspNetCore.Identity;
using ecommerce.infrutructure.ExtensionMethod;
using ecommerce.Domain.Entities.Identity;
using ecommerce_shared.Redis;
using ecommerce_shared.Extension;
using Newtonsoft.Json.Linq;
using ecommerce_shared.Services.Email;

namespace ecommerce.service.UserService
{
    public class AccountService:IAccountService
    {

<<<<<<< HEAD
        protected UserManager<Account> UserManager;
        public readonly ICacheRepository CacheRepository;
        public readonly IMailService MailService;

        protected SignInManager<Account> SignInManager;
        
        public AccountService(IMailService MailService,ICacheRepository CacheRepository,UserManager<Account> UserManager, SignInManager<Account> SignInManager)
=======
        protected UserManager<IdentityUser<Guid>> UserManager;
        protected SignInManager<IdentityUser<Guid>> SignInManager;
        public AccountService(UserManager<IdentityUser<Guid>> UserManager, SignInManager<IdentityUser<Guid>> SignInManager)
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
        {
            this.CacheRepository = CacheRepository; 
            this.UserManager= UserManager;
            this.SignInManager = SignInManager; 
            this.MailService= MailService;
        }

        public async Task<IdentityUser<Guid>> SignInAccountAsync(string UserNameOrEmail,string Password)
        {


            return null;
            //IdentityUser<Guid> Account = await UserManager.FindByNameOrEmailAsync(UserNameOrEmail);

            //if(Account == null)
            //{

            //    throw new Exception("UserName Or Email Is Not Correct");
            //}

            //var SigninResult=await SignInManager.CheckPasswordSignInAsync(Account, Password,false);
            //if (!SigninResult.Succeeded)
            //{

            //    throw new Exception("Your Credentials is Not Correct");

            //}

            //return Account;

        }


        public async Task<bool> CreateAccountAsync(IdentityUser<Guid> Account,string password)
        {

            var Accountresult = await this.UserManager.CreateAsync(Account, password);
            if (!Accountresult.Succeeded)
            {
                throw new CanotCreateAccountException(Accountresult.Errors);
            }
            return true;

        }

        public async Task<bool> Logout(string Token)
        {

            CacheRepository.RemoveData($"Token:{Token}");
            return true;

        }

        public async Task<bool> SendEmail(string Email)
        {

            
            var Account= await UserManager.FindByNameOrEmailAsync(Email);
            
            string Code= string.Empty.GenerateCode();
            Account.Code = Code;
            Account.ResetExpire = DateTime.Now.AddMinutes(10);
            await UserManager.UpdateAsync(Account);
            MailService.SendMail(Email, Code);
            return true;

        }



    }
}
