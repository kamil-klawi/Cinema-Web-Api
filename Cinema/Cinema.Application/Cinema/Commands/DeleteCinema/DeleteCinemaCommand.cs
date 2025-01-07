using MediatR;

namespace Cinema.Application.Cinema.Commands.DeleteCinema;

public class DeleteCinemaCommand(int id) : IRequest
{
    public int Id { get; } = id;
}