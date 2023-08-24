using Azure.Core;
using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce.Repository.PageRepository;
using ecommerce_shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using Repositories.ExtensionMethod;
using Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.UserService
{
    public class AccountService:IAccountService
    {

        protected UserManager<Account> UserManager;
        protected SignInManager<Account> SignInManager;
        public AccountService(UserManager<Account> UserManager, SignInManager<Account> SignInManager)
        {
            this.UserManager= UserManager;
            this.SignInManager = SignInManager; 
        }

        public async Task<Account> SignInAccountAsync(string UserNameOrEmail,string Password)
        {

            Account Account = await UserManager.FindByNameOrEmailAsync(UserNameOrEmail);

            if(Account == null)
            {

                throw new Exception("UserName Or Email Is Not Correct");
            }

            var SigninResult=await SignInManager.CheckPasswordSignInAsync(Account, Password,false);
            if (!SigninResult.Succeeded)
            {

                throw new Exception("Your Credentials is Not Correct");

            }

            return Account;

        }


        public async Task<bool> CreateAccountAsync(Account Account,string password)
        {

            var Accountresult = await this.UserManager.CreateAsync(Account, password);
            if (!Accountresult.Succeeded)
            {
                throw new CanotCreateAccountException(Accountresult.Errors);
            }
            return true;

        }

    }
}
