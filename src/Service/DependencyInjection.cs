using ecommerce.service.BrandService;
using ecommerce.service.PageService;
using ecommerce.service.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerce.service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPageService, ecommerce.service.PageService.PageService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, ecommerce.service.UserService.UserService>();
            services.AddTransient<IBrandService, ecommerce.service.BrandService.BrandService>();

            return services;

        }

    }
}
