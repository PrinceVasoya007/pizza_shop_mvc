using System.Security.Claims;

namespace pizza_shop_MVC.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken( string email , string password, string role);
        object GenerateJwtToken(string email, string password, int? roleId);

        ClaimsPrincipal? ValidateToken(string token);
    }
}
