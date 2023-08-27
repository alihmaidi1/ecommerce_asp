using ecommerce.Repository.Page;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Page;
using Repositories.RefreshToken;
using Repositories.Role;

namespace Repositories
{
    public static class dependencyInjection
    {

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IPageRepository,PageRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            return services;

        }
    }
}
