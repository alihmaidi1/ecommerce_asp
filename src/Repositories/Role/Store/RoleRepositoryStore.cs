using ecommerce.Domain.Enum;
using ecommerce.infrutructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Role.Store
{
    public static class RoleRepositoryStore
    {



        public static IQueryable<IdentityRole<Guid>> RoleWithoutBaseAdmins(this RoleManager<IdentityRole<Guid>> RoleManager)
        {


            return RoleManager.Roles.Where(x=>(!x.Name.Equals(nameof(RoleEnum.SuperAdmin))&& !x.Name.Equals(nameof(RoleEnum.DeliveryMan))));

        }

    }
}
