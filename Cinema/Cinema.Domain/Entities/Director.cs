namespace Cinema.Domain.Entities;

public class Director
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public List<Movie> Movies { get; set; } = [];
}