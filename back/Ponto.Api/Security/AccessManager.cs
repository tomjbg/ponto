using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Ponto.Domain.Interfaces;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using System.Security.Claims;
using Ponto.Api.Dto;
using Ponto.Data.Identities;

namespace Ponto.Api.Security
{
    public class AccessManager : IAccessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _configuration;
        private AppSettingsJWT _appSettingsJWT = new AppSettingsJWT();

        public AccessManager(UserManager<ApplicationUser> userManager, 
                             SignInManager<ApplicationUser> signInManager,
                             IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<Token> GerarToken(string username)
        {

            var user = await _userManager.FindByNameAsync(username);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }
            

            var appsettingsjwt = _configuration.GetSection("AppSettingsJWT");
            //new ConfigureFromConfigurationOptions<AppSettingsJWT>(appsettingsjwt)
            //                .Configure(_appSettingsJWT);

            new ConfigureFromConfigurationOptions<AppSettingsJWT>(appsettingsjwt).Configure(_appSettingsJWT);

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettingsJWT.Secret));
            var key = Encoding.ASCII.GetBytes(_appSettingsJWT.Secret);

            var handler = new JwtSecurityTokenHandler();


            //var securityToken = handler.CreateToken(new SecurityTokenDescriptor()
            //{
            //     Issuer = _appSettingsJWT.Emissor,
            //     Audience = _appSettingsJWT.ValidoPara,
            //    //NotBefore = DateTime.UtcNow,
            //    Expires = DateTime.UtcNow.AddMinutes(_appSettingsJWT.ExpiracaoMinutos),
            //    Subject = new ClaimsIdentity(claims),
            //     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //});
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(claims);

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "iPonto.com.br",
                Audience = "http://localhost/",
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(10),
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            }); 

            var token = handler.WriteToken(securityToken);

            return new Token() {
                Authenticated=true,
                Created = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = DateTime.UtcNow.AddMinutes(_appSettingsJWT.ExpiracaoMinutos).ToString("yyyy-MM-dd HH:mm:ss"),
                Username = user.UserName,
                AccessToken = token,
                Message = "Ok"
            };
        }

        public async Task<bool> ValidarCredencial(ApplicationUser user)
        {
            var credencialValida = false;

            var userIdentity= _userManager.FindByNameAsync(user.UserName);

            if (userIdentity != null)
            {
               var loginResult = await _signInManager.CheckPasswordSignInAsync(user, user.PasswordHash, true);

                credencialValida = loginResult.Succeeded;
            }

            return credencialValida;

        }

    }
}
