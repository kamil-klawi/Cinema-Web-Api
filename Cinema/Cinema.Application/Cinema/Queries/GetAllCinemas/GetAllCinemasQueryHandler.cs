using AutoMapper;
using Cinema.Application.Cinema.Dtos;
using Cinema.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Cinema.Queries.GetAllCinemas;

public class GetAllCinemasQueryHandler(
    ILogger<GetAllCinemasQueryHandler> logger,
    IMapper mapper,
    ICinemaRepository repository) : IRequestHandler<GetAllCinemasQuery, IEnumerable<CinemaDto>>
{
    public async Task<IEnumerable<CinemaDto>> Handle(GetAllCinemasQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Retrieving all cinemas");
        var cinemas = await repository.GetAllCinemas();
        return mapper.Map<List<CinemaDto>>(cinemas);
    }
}