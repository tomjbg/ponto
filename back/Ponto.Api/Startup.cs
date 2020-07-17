using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.SqlServer;
using Ponto.Data.Context;
using AutoMapper;
using Ponto.Api.Configurations;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ponto.Api.Security;
using Microsoft.AspNetCore.Identity;
using Ponto.Data.Identities;

namespace Ponto.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<PontoDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentityConfig();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(typeof(Startup));

            services.AddCors();
            
            services.AddDependencyInjection();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // JWT
            services.AddJWTConfig(Configuration);

            //var appSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);

            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //services.AddAuthentication(o =>
            //{
            //    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o =>
            //{
            //    o.RequireHttpsMetadata = true;
            //    o.SaveToken = true;
            //    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudience = appSettings.ValidoEm,
            //        ValidIssuer = appSettings.Emissor
            //    };
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                                UserManager<ApplicationUser> userManager,
                                PontoDBContext pontoDbContext,
                                ApplicationDbContext applicationDbContext,
                                Semeadora semeadora)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            //new InitializeDb(pontoDbContext, applicationDbContext);
            //semeadora.SemearUsuarios();


            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

        }
    }
}
