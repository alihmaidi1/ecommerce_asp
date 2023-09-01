<<<<<<< HEAD
﻿using ecommerce.Domain.Entities.Identity;
=======
﻿
using ecommerce.Domain.Entities;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
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
