using Cinema.Application.Cinema.Dtos;
using MediatR;

namespace Cinema.Application.Cinema.Queries.GetCinemaById;

public class GetCinemaByIdQuery(int id) : IRequest<CinemaDto?>
{
    public int Id { get; } = id;
}