using ecommerce.Repository.PageRepository;
using Microsoft.Extensions.DependencyInjection;
using Repositories.RefreshToken;
using Repositories.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
