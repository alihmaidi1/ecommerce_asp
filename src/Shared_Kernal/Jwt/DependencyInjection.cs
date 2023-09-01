using ecommerce_shared.Enums;
using ecommerce_shared.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ecommerce_shared.Jwt
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddJwtConfigration(this IServiceCollection services, IConfiguration Configuration)
        {
            var JwtOption = Configuration.GetSection("AccessToken");
            var ResetOption = Configuration.GetSection("ResetPassword");


            services.AddAuthentication(options =>
            {

                
                options.DefaultAuthenticateScheme= nameof(JwtSchema.Main);
                options.DefaultChallengeScheme= nameof(JwtSchema.Main);
                options.DefaultScheme = nameof(JwtSchema.Main);
            }).AddJwtBearer(nameof(JwtSchema.Main), options =>
                {                
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = JwtOption["Issuer"] ,
                    ValidAudience = JwtOption["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOption["Key"]))


                };
                options.Events = new JwtBearerEvents
                {

                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        throw new UnAuthenticationException();

                        
                    },

                    OnForbidden=async context =>
                    {

                        
                        
                        throw new UnAuthorizationException();


                    }



                };
                


            }).AddJwtBearer(nameof(JwtSchema.ResetPassword),options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = ResetOption["Issuer"],
                    ValidAudience = ResetOption["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ResetOption["Key"]))


                };
                options.Events = new JwtBearerEvents
                {

                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        throw new UnAuthenticationException();


                    },

                    OnForbidden = async context =>
                    {



                        throw new UnAuthorizationException();


                    }



                };



            });
            return services;

        }

    }
}
