﻿using ecommerce.Domain.Entities;
using ecommerce.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class PermissionSeed
    {


        public static async Task seedData(RoleManager<IdentityRole<Guid>> RoleManager,ApplicationDbContext context)
        {

            await SuperAdminSeed(RoleManager, context);


        }

        public static async Task SuperAdminSeed(RoleManager<IdentityRole<Guid>> RoleManager, ApplicationDbContext context)
        {

            var SuperAdmin = RoleManager.Roles.FirstOrDefault(x => x.Name.Equals(nameof(RoleEnum.SuperAdmin)));
            var Claims = await RoleManager.GetClaimsAsync(SuperAdmin);
            if (SuperAdmin != null && !Claims.Any())
            {
                List<RoleClaim> Permissions = Enum.GetNames(typeof(PermissionEnum)).Select(x=>new RoleClaim { RoleId=SuperAdmin.Id,ClaimType=nameof(ClaimEnum.Permission),ClaimValue=x }).ToList();                    
                context.BulkInsert(Permissions);
                context.SaveChanges();
            }



        }

    }
}
