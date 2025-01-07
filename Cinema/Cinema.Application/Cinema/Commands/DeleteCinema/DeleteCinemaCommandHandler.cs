using MediatR;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Cinema.Commands.DeleteCinema;

public class DeleteCinemaCommandHandler(
    ILogger<DeleteCinemaCommandHandler> logger, 
    ICinemaRepository repository) : IRequestHandler<DeleteCinemaCommand>
{
    public async Task Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Delete cinema {@request.Id}", request.Id);
        var cinema = await repository.GetCinemaById(request.Id);
        
        if (cinema == null)
            throw new NotFoundException(nameof(cinema), request.Id.ToString());
        
        await repository.DeleteCinema(cinema);
    }
}