using Cinema.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.User.Commands.UnAssignUserRole;

public class UnAssignUserRoleCommandHandler(
    ILogger<UnAssignUserRoleCommandHandler> logger, 
    UserManager<CinemaEntities.User> userManager, 
    RoleManager<IdentityRole> roleManager) : IRequestHandler<UnAssignUserRoleCommand>
{
    public async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Unassigning user role to user: {@request.Email}", request.Email);
        var user = await userManager.FindByEmailAsync(request.Email) 
                   ?? throw new NotFoundException(nameof(CinemaEntities.User), request.Email);
        
        var role = await roleManager.FindByNameAsync(request.Role.ToString())
                   ?? throw new NotFoundException(nameof(IdentityRole), request.Role.ToString());

        await userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}