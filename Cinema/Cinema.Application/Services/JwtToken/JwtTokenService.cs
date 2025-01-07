using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.Services.JwtToken;

public class JwtTokenService : IJwtTokenService
{
    private readonly string secretKey = "your-very-secret-key";

    public string GenerateToken(CinemaEntities.User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "CinemaWebApi",
            audience: "CinemaWebApi",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}