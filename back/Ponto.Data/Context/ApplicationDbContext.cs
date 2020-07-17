using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ponto.Data.Identities;

namespace Ponto.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            IdentityRole adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = "ADMIN";

            IdentityRole userRole = new IdentityRole("User");
            userRole.NormalizedName = "USER";
            
            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "tgds.net@outlook.com.br",
                NormalizedEmail = "TGDS.NET@OUTLOOK.COM.BR",
                NormalizedUserName = "TGDS.NET@OUTLOOK.COM.BR",
                Email = "tgds.net@outlook.com.br",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var password = new PasswordHasher<ApplicationUser>();
            var pwd = password.HashPassword(admin, "Admin@#2019");
            admin.PasswordHash = pwd;

            builder.Entity<IdentityRole>().HasData(adminRole, userRole);
            builder.Entity<ApplicationUser>().HasData(admin);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { UserId = admin.Id, RoleId = adminRole.Id }
                );



            base.OnModelCreating(builder);
        }

    }
}
