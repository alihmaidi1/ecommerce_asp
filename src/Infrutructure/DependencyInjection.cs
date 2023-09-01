<<<<<<< HEAD
﻿using ecommerce.Domain.Entities.Identity;
=======
﻿
using ecommerce.Domain.Entities;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
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

            services.AddIdentity<IdentityUser<Guid>, Role>(options =>
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
                option.UseLazyLoadingProxies()                
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));                
                option.LogTo(Console.WriteLine,LogLevel.Information);
                option.EnableSensitiveDataLogging();                                

            });
            


            

            return services;

        }

    }
}
