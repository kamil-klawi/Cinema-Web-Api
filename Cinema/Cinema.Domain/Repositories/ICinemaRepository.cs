namespace Cinema.Domain.Repositories;

public interface ICinemaRepository
{
    Task<IEnumerable<Entities.Cinema>> GetAllCinemas();
    Task<Entities.Cinema?> GetCinemaById(int id);
    Task<int> CreateCinema(Entities.Cinema entity);
    Task DeleteCinema(Entities.Cinema entity);
    Task UpdateCinema();
}