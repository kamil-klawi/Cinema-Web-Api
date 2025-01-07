using Cinema.Application.Services.JwtToken;
using Cinema.Domain.Entities;
using Cinema.Domain.Repositories;
using Cinema.Infrastructure.Persistence;
using Cinema.Infrastructure.Repositories;
using Cinema.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CinemaDb");
        services.AddDbContext<CinemaDbContext>(options => options.UseNpgsql(connectionString));
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, IdentityRole>>()
            .AddEntityFrameworkStores<CinemaDbContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<ICinemaSeeder, CinemaSeeder>();
        services.AddScoped<ICinemaRepository, CinemaRepository>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}