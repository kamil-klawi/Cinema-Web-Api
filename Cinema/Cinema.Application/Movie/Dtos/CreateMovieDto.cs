using Cinema.Application.Actor.Dtos;
using Cinema.Application.Director.Dtos;

namespace Cinema.Application.Movie.Dtos;

public class CreateMovieDto
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string Harbinger { get; set; } = default!;
    public int Rating { get; set; }
    public DateOnly ReleaseDate { get; set; }
    
    public List<ActorDto> Actors { get; set; } = [];
    public DirectorDto Director { get; set; } = default!;
}