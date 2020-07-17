using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace Ponto.Api.Configurations
{

    public class AuthorizeClaimsAttribute : TypeFilterAttribute
    {
        public AuthorizeClaimsAttribute(string claimName, string claimValue) : base(typeof(RequisitoAutorizacaoFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }


    public class RequisitoAutorizacaoFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        public RequisitoAutorizacaoFilter(Claim claim)
        {
            _claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!(context.HttpContext.User.Identity.IsAuthenticated &&
                context.HttpContext.User.Claims
                .Any(c=> c.Type == _claim.Type && c.Value == _claim.Value))                
                )
            {
                context.Result = new StatusCodeResult(403);
            }

        }
    }

}
