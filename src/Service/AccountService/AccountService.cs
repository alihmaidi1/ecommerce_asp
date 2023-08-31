
using ecommerce_shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using ecommerce.infrutructure.ExtensionMethod;
namespace ecommerce.service.UserService
{
    public class AccountService:IAccountService
    {

        protected UserManager<IdentityUser<Guid>> UserManager;
        protected SignInManager<IdentityUser<Guid>> SignInManager;
        public AccountService(UserManager<IdentityUser<Guid>> UserManager, SignInManager<IdentityUser<Guid>> SignInManager)
        {
            this.UserManager= UserManager;
            this.SignInManager = SignInManager; 
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

    }
}
