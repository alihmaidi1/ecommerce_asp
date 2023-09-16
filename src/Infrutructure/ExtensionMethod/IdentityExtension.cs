using ecommerce.Domain.Entities;
using ecommerce.Domain.Entities.Identity;
using ecommerce.Domain.Enum;
using ecommerce.Dto.Results.Admin.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.infrutructure.ExtensionMethod
{
    public static class IdentityExtension
    {

        //public static async Task<Account> FindByNameOrEmailAsync(this UserManager<Account> UserManager,string UserNameOrEmail)
        //{
        //    var UserName = UserName;
        //    var User = await UserManager.FindByEmailAsync(UserName);
        //    if (User != null) { 
            
        //        UserName=User.UserName;
        //    }
        //    return await UserManager.FindByNameAsync(UserName);            
        //}


        public static IQueryable<RoleClaim> GetAccountCalims(this ApplicationDbContext DBContext,Guid Id)
        {

            var Claims = from ur in DBContext.UserRoles
                         where ur.UserId == Id
                         join r in DBContext.Roles on ur.RoleId equals r.Id
                         join rc in DBContext.RoleClaims on r.Id equals rc.RoleId
                         select rc;
            return Claims;
        }


        public static IQueryable<object> GetRoleWithClaim(this ApplicationDbContext DBContext,Guid id)
        {

            var Role=from r in DBContext.Roles
                     where r.Id == id
                     join rc in DBContext.RoleClaims on r.Id equals rc.RoleId

                     select new  { 
                     
                         Id=r.Id,
                         Name=r.Name,
                         permissions=rc

                         
                        
                     };


            return Role;

        }


        public static Account FindAccountByEmailAndRole(this ApplicationDbContext Context, string Email,string RoleName)
        {
            var Account = from account in Context.Accounts
                         where (
                                  (account.Email == Email) &&
                                  (from userrole in Context.UserRoles
                                   join role in Context.Roles
                                   on userrole.RoleId equals role.Id
                                   where (account.Id == userrole.UserId && role.Name.Equals(RoleName))
                                   select role.Name)
                                   .Any()
                               )
                         select account;

            return Account.FirstOrDefault();

        }
        public static List<string> GetAccountRoles(this ApplicationDbContext DBContext,Guid Id) 
        {

            var roles = from role in DBContext.Roles
                        join userroles in DBContext.UserRoles on role.Id equals userroles.RoleId
                        where userroles.UserId == Id
                        select role.Name;
            return roles.ToList();

        }
    }
}
