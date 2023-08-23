using ecommerce.Domain.Abstract;
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

        public static async Task seedData(RoleManager<IdentityRole<Guid>> _roleManager)
        {
            int count=await _roleManager.Roles.CountAsync();
            if (count == 0)
            {

                var roles=Enum.GetNames(typeof(Role));
                foreach (var name in roles)
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid> { Name=name});
                }


            }

        }


    }
}
