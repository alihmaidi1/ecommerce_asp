using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace ecommerce.user
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserdependency(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));           
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
