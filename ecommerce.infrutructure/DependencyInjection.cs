using ecommerce.Domain.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
                options.Password.RequireNonAlphanumeric = true; 
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;  
                options.Password.RequireUppercase = true;

            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });

            
            return services;

        }

    }
}
