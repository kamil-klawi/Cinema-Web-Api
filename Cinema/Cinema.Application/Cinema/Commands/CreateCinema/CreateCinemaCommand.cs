using MediatR;

namespace Cinema.Application.Cinema.Commands.CreateCinema;

public class CreateCinemaCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public TimeSpan OpenTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
}