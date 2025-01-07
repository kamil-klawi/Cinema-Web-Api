using Cinema.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CinemaEntity = Cinema.Domain.Entities;

namespace Cinema.Application.User.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler(
    ILogger<AssignUserRoleCommandHandler> logger,
    UserManager<CinemaEntity.User> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning user role to user: {@request.Email}", request.Email);
        var user = await userManager.FindByEmailAsync(request.Email)
            ?? throw new NotFoundException(nameof(CinemaEntity.User), request.Email);

        var role = await roleManager.FindByNameAsync(request.Role.ToString())
            ?? throw new NotFoundException(nameof(IdentityRole), request.Role.ToString());
        
        await userManager.AddToRoleAsync(user, role.Name!);
    }
}