using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ponto.Api.Security;
using System.Text;

namespace Ponto.Api.Configurations
{
    public static class JWTConfig
    {
        public static IServiceCollection AddJWTConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // JWT

            IConfigurationSection appsettingsjwtSection = configuration.GetSection("AppSettingsJWT");
            services.Configure<AppSettingsJWT>(appsettingsjwtSection);
            
            var appsettingsjwt = appsettingsjwtSection.Get<AppSettingsJWT>();
            var key = Encoding.ASCII.GetBytes(appsettingsjwt.Secret);

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appsettingsjwt.Emissor,
                    ValidAudience = appsettingsjwt.ValidoPara,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });


            //// Ativando a Autorização por token Bearer
            //services.AddAuthorization(o =>
            //{
            //    o.AddPolicy("Bearer", b => 
            //                b.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            //                .RequireAuthenticatedUser());
            //});



            return services;
        }
    }
}
