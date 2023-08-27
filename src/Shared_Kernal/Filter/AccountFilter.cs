using ecommerce.infrutructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Filter
{
    public static class AccountFilter
    {

        public static IQueryable GetAccountClaim(this ApplicationDbContext DbContext, string AccountId)
        {

            var claims = from ur in DbContext.UserRoles
                         where ur.UserId.Equals(AccountId)
                         join r in DbContext.Roles on ur.RoleId equals r.Id
                         join rc in DbContext.RoleClaims on r.Id equals rc.RoleId
                         select rc;

            return claims;

        }
    }
}
