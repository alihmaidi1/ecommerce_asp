using ecommerce.Domain.Entities;
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
        public RoleManager<ecommerce.Domain.Entities.Role> RoleManager;
        public RoleRepository(RoleManager<ecommerce.Domain.Entities.Role> RoleManager) { 
        

            this.RoleManager = RoleManager;

        }



        public List<ecommerce.Domain.Entities.Role> GetAllRole()
        {
            
            var Roles=RoleManager.RoleWithoutBaseAdmins().ToList();
            return Roles;
        }






    }
}
