using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.User.Commands.CreateUser;

public class CreateUserCommandHandler(
    ILogger<CreateUserCommandHandler> logger,
    IMapper mapper,
    UserManager<CinemaEntities.User> userManager) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new user: {@request.FirstName} {@request.LastName}", request.FirstName, request.LastName);
        var user = mapper.Map<CinemaEntities.User>(request);
        await userManager.CreateAsync(user, request.Password);
    }
}