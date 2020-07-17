using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ponto.Data.Identities;
using System;
using System.Linq;

namespace Ponto.Data.Context
{
    public class Semeadora
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Semeadora(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async void SemearUsuarios()
        {
            

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "tgds.net@outlook.com.br",
                Email = "tgds.net@outlook.com.br",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            
            // Roles
            var _roleManager = new RoleStore<IdentityRole>(_applicationDbContext);
            var role = new IdentityRole("Admin");
            role.NormalizedName = "ADMIN";
            if (!_roleManager.Roles.Any(r=>r.Name=="Admin"))
            {
                
                await _roleManager.CreateAsync(role);
            }
            

            // Users
            var _userManager = new UserStore<ApplicationUser>(_applicationDbContext);
            if (!_userManager.Users.Any(u=>u.UserName==admin.UserName))
            {
                var passHash = new PasswordHasher<ApplicationUser>().HashPassword(admin, "Admin@#2019");
                admin.PasswordHash = passHash;
                await _userManager.CreateAsync(admin);
            }
            // UserRoles
            //var lstRoles = await _userManager.GetRolesAsync(admin);

            //if (!_userManager.GetRolesAsync(admin).Result.Contains("Admin") &&
            //    _roleManager.Roles.Any(r=>r.Name=="Admin"))
            //{
            //    await _userManager.AddToRoleAsync(admin, "ADMIN");
            //}




            await _applicationDbContext.SaveChangesAsync();
        }





    }
}
