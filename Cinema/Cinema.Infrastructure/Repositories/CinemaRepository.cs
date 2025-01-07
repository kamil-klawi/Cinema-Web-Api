using Cinema.Domain.Repositories;
using Cinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Infrastructure.Repositories;

public class CinemaRepository(CinemaDbContext dbContext) : ICinemaRepository
{
    public async Task<IEnumerable<CinemaEntities.Cinema>> GetAllCinemas()
    {
        return await dbContext.Cinemas.ToListAsync();
    }

    public async Task<CinemaEntities.Cinema?> GetCinemaById(int id)
    {
        return await dbContext.Cinemas
            .Include(m => m.Movies)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<int> CreateCinema(CinemaEntities.Cinema entity)
    {
        dbContext.Cinemas.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteCinema(CinemaEntities.Cinema entity)
    {
        dbContext.Cinemas.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateCinema() => await dbContext.SaveChangesAsync();
}