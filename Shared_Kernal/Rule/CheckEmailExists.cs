using ecommerce.Domain.Abstract;
using ecommerce.infrutructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Rule
{
    public static class CheckEmailExists
    {

        public static async Task<bool> IsEmailExistsAsync(string email,UserManager<Account> UserManager)
        {

            var user=await UserManager.FindByEmailAsync(email);

            return user!=null;

        }



    }
}
