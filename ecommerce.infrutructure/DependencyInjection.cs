using ecommerce.Domain.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrustucture(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddIdentity<Account, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false; 
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;  
                options.Password.RequireUppercase = false;

            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                option.LogTo(Console.WriteLine,LogLevel.Information);
                option.EnableSensitiveDataLogging();                                

            });
            

            

            return services;

        }

    }
}
