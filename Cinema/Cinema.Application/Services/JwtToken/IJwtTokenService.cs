using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.Services.JwtToken;

public interface IJwtTokenService
{
    string GenerateToken(CinemaEntities.User user);
}