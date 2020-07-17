using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ponto.Api.Configurations;
using Ponto.Api.Dto;
using Ponto.Api.Security;
using Ponto.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Ponto.Api.Controllers;
using Ponto.Data.Identities;
using System.Security.Claims;

namespace Ponto.Api.V1.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : MainController
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccessManager _accessManager;

        public AuthController(INotificador notificador, 
                              IOptions<AppSettings> appSettings,
                              UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              IAccessManager accessManager) : base(notificador)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _accessManager = accessManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto login)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, true);

            if (result.Succeeded)
            {
                var token = await _accessManager.GerarToken(login.Email);
                return CustomResponse(token);
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tenativas inválidas");
                return CustomResponse(login);
            }
            NotificarErro("Usuário ou Senha incorretos");

            return CustomResponse(login);
        }

        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(RegistrarDto registrar)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new ApplicationUser()
            {
                UserName = registrar.Email,
                Email = registrar.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user,registrar.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await _accessManager.GerarToken(user.UserName));
            }

            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(registrar);
        }



        //private async Task<string> GerarJwt(string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    var roles = await _userManager.GetRolesAsync(user);
        //    var claims = await _userManager.GetClaimsAsync(user);

        //    var claimsIdentity = new ClaimsIdentity(claims);
            

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Issuer = _appSettings.Emissor,
        //        Audience = _appSettings.ValidoEm,
        //        Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_appSettings.ExpiracaoHoras)),
        //        Subject = claimsIdentity,
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
        //                                                    SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        //}


    }
}