using Microsoft.AspNetCore.Identity;
using Repositories.Role.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Role
{
    public class RoleRepository:IRoleRepository
    {
        public RoleManager<IdentityRole<Guid>> RoleManager;
        public RoleRepository(RoleManager<IdentityRole<Guid>> RoleManager) { 
        

            this.RoleManager = RoleManager;

        }



        public List<IdentityRole<Guid>> GetAllRole()
        {
            
            var Roles=RoleManager.RoleWithoutBaseAdmins().ToList();
            return Roles;
        }






    }
}
