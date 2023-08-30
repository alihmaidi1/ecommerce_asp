using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.infrutructure.ExtensionMethod
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


        public static IQueryable<RoleClaim> GetAccountCalims(this ApplicationDbContext DBContext,Guid Id)
        {

            var Claims = from ur in DBContext.UserRoles
                         where ur.UserId == Id
                         join r in DBContext.Roles on ur.RoleId equals r.Id
                         join rc in DBContext.RoleClaims on r.Id equals rc.RoleId
                         select rc;
            return Claims;
        }

        public static List<string> GetUserRoles(this ApplicationDbContext DBContext,Guid Id) 
        {

            var roles = from role in DBContext.Roles
                        join userroles in DBContext.UserRoles on role.Id equals userroles.RoleId
                        where userroles.UserId == Id
                        select role.Name;
            return roles.ToList();

        }
    }
}
