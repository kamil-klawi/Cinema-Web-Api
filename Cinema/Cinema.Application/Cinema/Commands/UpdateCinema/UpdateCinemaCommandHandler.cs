using AutoMapper;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Cinema.Commands.UpdateCinema;

public class UpdateCinemaCommandHandler(
    ILogger<UpdateCinemaCommandHandler> logger,
    IMapper mapper,
    ICinemaRepository repository) : IRequestHandler<UpdateCinemaCommand>
{
    public async Task Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating {@request.Name}", request.Name);
        var cinema = await repository.GetCinemaById(request.Id);
        
        if (cinema == null)
            throw new NotFoundException(nameof(cinema), request.Id.ToString());
        
        mapper.Map(request, cinema);
        await repository.UpdateCinema();
    }
}