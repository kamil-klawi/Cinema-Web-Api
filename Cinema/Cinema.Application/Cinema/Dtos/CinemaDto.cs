using Cinema.Application.Movie.Dtos;

namespace Cinema.Application.Cinema.Dtos;

public class CinemaDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public TimeSpan OpenTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
    
    public List<MovieDto> Movies { get; set; } = [];
}