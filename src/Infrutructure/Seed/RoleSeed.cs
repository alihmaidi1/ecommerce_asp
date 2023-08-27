using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class RoleSeed
    {

        public static async Task seedData(RoleManager<Role> _roleManager)
        {
            bool exists=_roleManager.Roles.Any();

            if (!exists)
            {

                var roles= System.Enum.GetNames(typeof(RoleEnum));
                foreach (var name in roles)
                {
                    await _roleManager.CreateAsync(new Role { Name=name});
                }



            }


        }


    }
}
