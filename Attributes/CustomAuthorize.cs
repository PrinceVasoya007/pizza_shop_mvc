using pizza_shop_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace pizza_shop_MVC.Attributes
{
    /// <summary>
    /// Extend with Attribute Class to make this class an Attribute.
    /// IAuthorizationFilter Interface used to implement the OnAuthorization lifeCycle method.
    /// </summary>
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Inject JwtService to use in Middleware.
            var jwtService = context.HttpContext.RequestServices.GetService(typeof(IJwtService)) as IJwtService;
            
            // Get the token from Cookie
            var token = context.HttpContext.Request.Cookies.TryGetValue("Authorize", out var userEmail);
        

            // Validate Token
            var principal = jwtService?.ValidateToken(userEmail ?? "");
            if (principal == null)
            {
                context.Result = new RedirectToActionResult("Login", "Index", null);
                return;
            }

            context.HttpContext.User = principal;

            if (_roles.Length > 0)
            {
                // Get Role Claim from the principal
                var userRole = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (!_roles.Contains(userRole))
                {
                    context.Result = new RedirectToActionResult("AccessDenied", "Login", null);
                }
            }
        }
    }
}
