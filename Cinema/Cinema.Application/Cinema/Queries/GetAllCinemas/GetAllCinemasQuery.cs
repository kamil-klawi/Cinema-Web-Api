using Cinema.Application.Cinema.Dtos;
using MediatR;

namespace Cinema.Application.Cinema.Queries.GetAllCinemas;

public class GetAllCinemasQuery : IRequest<IEnumerable<CinemaDto>>
{
    
}