using AutoMapper;
using Cinema.Application.Cinema.Dtos;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Cinema.Queries.GetCinemaById;

public class GetCinemaByIdQueryHandler(
    ILogger<GetCinemaByIdQueryHandler> logger, 
    IMapper mapper,
    ICinemaRepository repository) : IRequestHandler<GetCinemaByIdQuery, CinemaDto?>
{
    public async Task<CinemaDto?> Handle(GetCinemaByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving cinema by Id: {@request.Id}", request.Id);
        var cinema = await repository.GetCinemaById(request.Id);
        
        if (cinema == null)
            throw new NotFoundException(nameof(cinema), request.Id.ToString());
        
        var cinemaDto = mapper.Map<CinemaDto?>(cinema);
        return cinemaDto;
    }
}