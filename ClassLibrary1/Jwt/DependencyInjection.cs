using ecommerce_shared.Exceptions;
using ecommerce_shared.Repository.interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Jwt
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddJwtConfigration(this IServiceCollection services, IConfiguration Configuration)
        {
            var JwtOption = Configuration.Get<JwtSetting>();
            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = JwtOption.Issuer,
                    ValidAudience = JwtOption.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("siodu9834h3troit3985ywyfhuwoer3284"))


                };
                options.Events = new JwtBearerEvents
                {

                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        throw new UnAuthenticationException();

                        
                    }



                };
                


            });
            return services;

        }

    }
}
