using Cinema.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.User.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    ILogger<UpdateUserCommandHandler> logger,
    IUserContext userContext,
    IUserStore<CinemaEntities.User> userStore) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating user details: {@request.Email}", request.Email);

        var user = userContext.GetCurrentUser();
        var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
        
        if (dbUser == null)
            throw new NotFoundException(nameof(CinemaEntities.User), user!.Id);
        
        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}