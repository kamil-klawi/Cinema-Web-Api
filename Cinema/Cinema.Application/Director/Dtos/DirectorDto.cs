using Cinema.Application.Movie.Dtos;

namespace Cinema.Application.Director.Dtos;

public class DirectorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    
    public List<MovieDto> Movies { get; set; } = [];
}