using AutoMapper;
using MediatR;
using CinemaEntities = Cinema.Domain.Entities;
using Cinema.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Cinema.Commands.CreateCinema;

public class CreateCinemaCommandHandler(
    ILogger<CreateCinemaCommandHandler> logger,
    IMapper mapper,
    ICinemaRepository repository) : IRequestHandler<CreateCinemaCommand, int>
{
    public async Task<int> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new cinema: {@request.Name}", request.Name);
        var cinema = mapper.Map<CinemaEntities.Cinema>(request);
        return await repository.CreateCinema(cinema);
    }
}