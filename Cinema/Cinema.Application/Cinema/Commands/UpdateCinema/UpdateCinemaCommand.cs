using MediatR;

namespace Cinema.Application.Cinema.Commands.UpdateCinema;

public class UpdateCinemaCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public TimeSpan OpenTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
}