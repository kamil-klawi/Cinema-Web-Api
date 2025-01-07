namespace Cinema.Domain.Entities;

public class Cinema
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public TimeSpan OpenTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public Address? Address { get; set; }
    
    public List<Movie> Movies { get; set; } = [];
}