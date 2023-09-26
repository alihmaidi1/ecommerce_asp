using ecommerce.Domain.Entities.Identity;
using ecommerce.infrutructure.Seed;
using ecommerce.infrutructure.Services.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nest;
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

            context.Database.EnsureDeleted();            
            context.Database.EnsureCreated();

            var transaction = context.Database.BeginTransaction();

            try
            {

                var RegionApi = services.GetRequiredService<ExternalRegionApi>();
                var RoleManager = services.GetRequiredService<RoleManager<Role>>();
                var UserManager = services.GetRequiredService<UserManager<Account>>();
                var ElasticService = services.GetRequiredService<IElasticClient>();
                
                await RoleSeed.seedData(RoleManager);
                await PermissionSeed.seedData(RoleManager, context);
                await AdminSeed.seedData(context, UserManager);
                await SliderSeed.seedData(context, ElasticService);
                await PageSeed.seedDate(context);
                await CurrencySeed.seedData(context);
                await BannerSeed.seedData(context);
                await BrandSeed.seedData(context, ElasticService);
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
            catch(Exception ex)
            {

                transaction.Rollback();
                throw new Exception(ex.Message);
            }


        }



    }
}
