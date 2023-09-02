using ecommerce.Repository.Page;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Account;
using Repositories.Country;
using Repositories.Jwt.Factory;
using Repositories.Page;
using Repositories.RefreshToken;
using Repositories.Role;
using Repositories.User;

namespace Repositories
{
    public static class dependencyInjection
    {

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            
            services.AddTransient<IPageRepository,PageRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ICountryRepository,CountryRepository>();
            services.AddTransient<IAccountRepository,AccountRepository>();
            services.AddTransient<ISchemaFactory, SchemaFactory>();
            services.AddTransient<IUserRepository, UserRepository>();   

            return services;

        }
    }
}
