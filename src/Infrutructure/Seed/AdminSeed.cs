<<<<<<< HEAD
﻿using ecommerce.Domain.Entities.Identity;
=======
﻿
using ecommerce.Domain.Entities;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
using ecommerce.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class AdminSeed
    {

        public static async Task<bool> CreateAdmin(ApplicationDbContext context, UserManager<IdentityUser<Guid>> UserManager, Admin Account,string Role,string Password="12345678")
        {
         
            var Result = await UserManager.CreateAsync(Account,Password);
            if (Result.Succeeded)
            {
                var RoleResult = await UserManager.AddToRoleAsync(Account, Role);

                if (RoleResult.Succeeded)
                {
<<<<<<< HEAD

                    context.Admins.Add(new Domain.Entities.Identity.Admin() { AccountId = Account.Id });
                    context.SaveChanges();
=======
                    context.Admins.Add(Account);
                    //context.SaveChanges();
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45

                }

            }

            return true;


        }
        public static async Task seedData(ApplicationDbContext context,UserManager<IdentityUser<Guid>> UserManager )
        {

            if (!context.Admins.Any())
            {

                var SuperAdmin = new Admin()
                {

                    UserName = "SuperAdmin",
                    Email = "alihmaidi095@gmail.com",
                };

                var DeliveryMan = new Admin()
                {
                    UserName="DeliveryMan",
                    Email= "DeliveryMan@admin.com"

                };

                 await CreateAdmin(context, UserManager, SuperAdmin,nameof(RoleEnum.SuperAdmin));
                 await CreateAdmin(context, UserManager, DeliveryMan, nameof(RoleEnum.DeliveryMan));


                

            }

        }

    }
}
