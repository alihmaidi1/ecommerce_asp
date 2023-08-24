using ecommerce.service.PageService;
using ecommerce.service.UserService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddTransient<IPageService, ecommerce.service.PageService.PageService>();
            services.AddTransient<IAccountService, AccountService>();
            return services;

        }

    }
}
