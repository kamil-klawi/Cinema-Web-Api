using Cinema.Domain.Constants;
using Cinema.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Infrastructure.Seeders;

internal class CinemaSeeder(CinemaDbContext dbContext) : ICinemaSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Cinemas.Any())
            {
                dbContext.Cinemas.AddRange(Cinemas());
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = Roles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> Roles()
    {
        List<IdentityRole> roles = [
            new IdentityRole(Role.ADMIN.ToString())
            {
                NormalizedName = Role.ADMIN.ToString()
            },
            new IdentityRole(Role.USER.ToString())
            {
                NormalizedName = Role.USER.ToString()
            }
        ];
        return roles;
    }

    private IEnumerable<Domain.Entities.Cinema> Cinemas()
    {
        List<Domain.Entities.Cinema> cinemas = [
            new ()
            {
                Name = "Multikino",
                OpenTime = new TimeSpan(9, 0, 0),
                ClosingTime = new TimeSpan(24, 0, 0),
                Address = new ()
                {
                    State = "Poland",
                    City = "Gdańsk",
                    Street = "Aleja Zwycięstwa 14",
                    ZipCode = "80-219",
                }
                
            }
        ];

        return cinemas;
    }
}