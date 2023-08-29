using ecommerce_shared.File.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.File
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddS3Configration(this IServiceCollection services)
        {
         
            services.AddTransient<IStorageService, StorageService>();
            return services;
        }

    }
}
