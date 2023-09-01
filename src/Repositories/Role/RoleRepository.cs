using Microsoft.AspNetCore.Identity;
using Repositories.Role.Store;

namespace Repositories.Role
{
    public class RoleRepository:IRoleRepository
    {
        public RoleManager<ecommerce.Domain.Entities.Identity.Role> RoleManager;
        public RoleRepository(RoleManager<ecommerce.Domain.Entities.Identity.Role> RoleManager) { 
        

            this.RoleManager = RoleManager;

        }



        public List<ecommerce.Domain.Entities.Identity.Role> GetAllRole()
        {
            
            var Roles=RoleManager.RoleWithoutBaseAdmins().ToList();
            return Roles;
        }






    }
}
