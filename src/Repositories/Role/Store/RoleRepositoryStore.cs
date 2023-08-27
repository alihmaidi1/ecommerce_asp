using ecommerce.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Repositories.Role.Store
{
    public static class RoleRepositoryStore
    {



        public static IQueryable<ecommerce.Domain.Entities.Role> RoleWithoutBaseAdmins(this RoleManager<ecommerce.Domain.Entities.Role> RoleManager)
        {


            return RoleManager.Roles.Where(x=>(!x.Name.Equals(nameof(RoleEnum.SuperAdmin))&& !x.Name.Equals(nameof(RoleEnum.DeliveryMan))));

        }

    }
}
