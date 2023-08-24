using ecommerce.Domain.Abstract;
using ecommerce.infrutructure.Seed;
using ecommerce.infrutructure.Services.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.seed
{
    public static class DatabaseSeed
    {

        public static async Task InitializeAsync(IServiceProvider services)
        {

            var context = services.GetRequiredService<ApplicationDbContext>();
            //await context.Database.MigrateAsync();
            var RegionApi = services.GetRequiredService<ExternalRegionApi>();
            var RoleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var UserManager = services.GetRequiredService<UserManager<Account>>();
            var transaction =context.Database.BeginTransaction();

                await RoleSeed.seedData(RoleManager);
                await AdminSeed.seedData(context,UserManager);
                await SliderSeed.seedData(context);
                await PageSeed.seedDate(context);
                await CurrencySeed.seedData(context);
                await BannerSeed.seedData(context);
                await BrandSeed.seedData(context);
                await CartSeed.seedData(context);
                await CategorySeed.seedData(context);
                await CountrySeed.seedData(context, RegionApi);
                await Cityseed.seedData(context, RegionApi);
                await CoponSeed.seedData(context);
                await ProductSeed.seedData(context);
                await PorpertySeed.seedData(context);
                await ReviewSeed.seedData(context);
                await transaction.CommitAsync();
                

        }



    }
}
