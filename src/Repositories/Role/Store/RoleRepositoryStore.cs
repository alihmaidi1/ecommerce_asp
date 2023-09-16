using ecommerce.Domain.Enum;
using ecommerce.infrutructure;
using Microsoft.AspNetCore.Identity;

namespace Repositories.Role.Store
{
    public static class RoleRepositoryStore
    {



        public static IQueryable<ecommerce.Domain.Entities.Identity.Role> RoleWithoutBaseAdmins(this RoleManager<ecommerce.Domain.Entities.Identity.Role> RoleManager)
        {


            return RoleManager.Roles.Where(x=>(!x.Name.Equals(nameof(RoleEnum.SuperAdmin))&& !x.Name.Equals(nameof(RoleEnum.DeliveryMan))));

        }

        public static IQueryable<ecommerce.Domain.Entities.Identity.Role> RoleWithoutSuperAdmin(this RoleManager<ecommerce.Domain.Entities.Identity.Role> RoleManager)
        {


            return RoleManager.Roles.Where(x => !x.Name.Equals(nameof(RoleEnum.SuperAdmin)));

        }

        public static IQueryable<ecommerce.Domain.Entities.Identity.Role> RoleWithoutBaseAdmins(this ApplicationDbContext Context)
        {


            return Context.Roles.Where(x => (!x.Name.Equals(nameof(RoleEnum.SuperAdmin)) && !x.Name.Equals(nameof(RoleEnum.DeliveryMan))));

        }
    }
}
