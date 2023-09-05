using AccountEntity = ecommerce.Domain.Entities.Identity.Account;
using Repositories.Base.Concrete;
using ecommerce.infrutructure;
using ecommerce.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ecommerce_shared.Helper;
using Microsoft.EntityFrameworkCore;
using ecommerce_shared.Enums;
using UserEntity = ecommerce.Domain.Entities.Identity.User;
using ecommerce_shared.Services.Authentication.ResponseAuth;
using AdminEntity=ecommerce.Domain.Entities.Identity.Admin;

namespace Repositories.Account
{
    public class AccountRepository : GenericRepository<AccountEntity>, IAccountRepository
    {

        public UserManager<AccountEntity> UserManager;

        public AccountRepository(ApplicationDbContext DBContext, UserManager<AccountEntity> UserManager) : base(DBContext)
        {

            this.UserManager = UserManager; 
            
        }

        public bool CheckRoleUserName(string UserName, RoleEnum Role)
        {
            var exists=from account in DbContext.Accounts
                       where (
                                (account.UserName==UserName) &&
                                (from userrole in DbContext.UserRoles
                                 join role in DbContext.Roles
                                 on userrole.RoleId equals role.Id
                                 where (account.Id == userrole.UserId && role.Name.Equals(Role.ToString()))
                                 select role.Name)
                                 .Any()                                                              
                             )
                       select 1;

            return exists.Any();  

        }



        public bool CheckAccountCode(string Code,AccountEntity Account)
        {
            return Code.Equals(Account.Code);

        }

        public bool CheckConfirmCode(string Code, AccountEntity Account)
        {

            return Code.Equals(Account.ConfirmCode);


        }

        public async Task<AccountEntity> CreateExternal(Response ApiResponse,ProviderAuthentication Provider)
        {

            UserEntity Account = DbContext.Users.CreateProxy();

            Account.EmailConfirmed = true;
            Account.Email = ApiResponse.Email;
            Account.UserName = StringHelper.GenerateRandomString(25);
            Account.ProviderId = ApiResponse.sub;
            Account.ProviderType = Provider;
            Account.Name = StringHelper.GenerateRandomString(10);
            var AccountResult=await UserManager.CreateAsync(Account, StringHelper.GenerateRandomString(25));            
            if(AccountResult.Succeeded)
            {

                return Account;
            }


            throw new Exception("can not create Account");

        }


    }
}
