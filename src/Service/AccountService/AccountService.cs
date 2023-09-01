using ecommerce_shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using ecommerce.infrutructure.ExtensionMethod;
using ecommerce.Domain.Entities.Identity;
using ecommerce_shared.Redis;
using ecommerce_shared.Extension;
using Newtonsoft.Json.Linq;
using ecommerce_shared.Services.Email;
using Repositories.Jwt;
using Repositories.Jwt.Factory;
using ecommerce_shared.Enums;

namespace ecommerce.service.UserService
{
    public class AccountService:IAccountService
    {

        protected UserManager<Account> UserManager;
        public readonly ICacheRepository CacheRepository;
        public readonly IMailService MailService;
        public readonly IJwtRepository jwtRepository;

        protected SignInManager<Account> SignInManager;
        
        public AccountService(ISchemaFactory SchemaFactory,IMailService MailService,ICacheRepository CacheRepository,UserManager<Account> UserManager, SignInManager<Account> SignInManager)
        {
            this.CacheRepository = CacheRepository; 
            this.UserManager= UserManager;
            this.SignInManager = SignInManager; 
            this.MailService= MailService;
            this.jwtRepository= SchemaFactory.CreateJwt(JwtSchema.Main);
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
