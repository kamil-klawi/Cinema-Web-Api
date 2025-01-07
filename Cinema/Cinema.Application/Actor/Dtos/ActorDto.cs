using Cinema.Application.Movie.Dtos;

namespace Cinema.Application.Actor.Dtos;

public class ActorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    
    public List<MovieDto> Movies { get; set; } = [];
}