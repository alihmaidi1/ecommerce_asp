using ecommerce.Domain.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Repositories.ExtensionMethod
{
    public static class IdentityExtension
    {

        public static async Task<Account> FindByNameOrEmailAsync(this UserManager<Account> UserManager,string UserNameOrEmail)
        {
            var UserName = UserNameOrEmail;
            var User = await UserManager.FindByEmailAsync(UserNameOrEmail);
            if (User != null) { 
            
                UserName=User.UserName;
            }
            return await UserManager.FindByNameAsync(UserName);


            
        }
    }
}
