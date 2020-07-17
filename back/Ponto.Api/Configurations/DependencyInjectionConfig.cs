using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ponto.Api.Security;
using Ponto.Data.Context;
using Ponto.Data.Identities;
using Ponto.Data.Repository;
using Ponto.Domain.Interfaces;
using Ponto.Domain.Notificacoes;
using Ponto.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<PontoDBContext>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAccessManager, AccessManager>();
            services.AddTransient<Semeadora>();


            return services;
        }
    }
}
