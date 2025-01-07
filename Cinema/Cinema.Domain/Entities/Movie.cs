namespace Cinema.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string Harbinger { get; set; } = default!;
    public int Rating { get; set; }
    public DateOnly ReleaseDate { get; set; }

    public List<Cinema> Cinemas { get; set; } = [];
    public List<Actor> Actors { get; set; } = [];
    public Director Director { get; set; } = default!;
    public int DirectorId { get; set; }
}