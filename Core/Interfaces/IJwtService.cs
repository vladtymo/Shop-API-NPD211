using System.Security.Claims;
using Data.Entities;

namespace Core.Interfaces;

public interface IJwtService
{
    // ------- Access Token
    IEnumerable<Claim> GetClaims(User user);
    string CreateToken(IEnumerable<Claim> claims);
}