using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string role);
        ClaimsPrincipal? ValidateToken(string token);
    }
}