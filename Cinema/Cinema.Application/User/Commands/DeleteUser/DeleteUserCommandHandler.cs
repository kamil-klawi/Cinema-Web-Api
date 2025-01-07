using Cinema.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.User.Commands.DeleteUser;

public class DeleteUserCommandHandler(
    ILogger<DeleteUserCommandHandler> logger, 
    UserManager<CinemaEntities.User> userManager) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Delete user {@request.Id}", request.Id);
        var user = await userManager.FindByIdAsync(request.Id);
        
        if (user == null)
            throw new NotFoundException(nameof(user), request.Id);
        
        await userManager.DeleteAsync(user);
    }
}