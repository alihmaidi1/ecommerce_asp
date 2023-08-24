using ecommerce.Domain.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
