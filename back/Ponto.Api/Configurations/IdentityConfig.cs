using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ponto.Data.Context;
using Ponto.Data.Identities;

namespace Ponto.Api.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services)
        {
            // Identity

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            

            services.Configure<IdentityOptions>(o =>
            {
                // Senha
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequiredLength = 6;
                o.Password.RequiredUniqueChars = 0;
                o.Password.RequireUppercase = false;

                // Lockout
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                o.Lockout.MaxFailedAccessAttempts = 6;

                // Usuario
                o.User.RequireUniqueEmail = false;
            });

            return services;
        }
    }
}
