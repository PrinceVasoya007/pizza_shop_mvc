using System.Security.Claims;

namespace AuthenticationDemo.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(string name, string email, string role);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
