using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Swagger
{
    public static class dependencyInjection
    {

        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {

            services.AddSwaggerGen(option =>
            {

                var openApiInfo = new OpenApiInfo()
                {

                    Version = "v1",
                    Title = "WebApi",
                };

                //create  swagger document
                typeof(ApiGroupName).GetFields().Skip(1).ToList().ForEach(f =>
                {
                    var info = f.GetCustomAttribute<GroupInfoAttribute>();
                        

                        
                        openApiInfo.Title = info.Title ;
                        openApiInfo.Version = info.Version;
                        openApiInfo.Description = info.Description;
                         option.SwaggerDoc(f.Name, openApiInfo);





                });


            });

            return services;

        }
        public static IApplicationBuilder ConfigureOpenAPI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //Skip (1) is because the first fieldinfo of enum is a built-in int value
                typeof(ApiGroupName).GetFields().Skip(1).ToList().ForEach(f =>
                {
                    //Gets the attribute on the enumeration value
                    var info = f.GetCustomAttributes(typeof(GroupInfoAttribute), false).OfType<GroupInfoAttribute>().FirstOrDefault();
                    c.SwaggerEndpoint($"/swagger/{f.Name}/swagger.json",  f.Name);                    
                });

                //c.DocExpansion(DocExpansion.None);
            });
            return app;
        }

    }
}
