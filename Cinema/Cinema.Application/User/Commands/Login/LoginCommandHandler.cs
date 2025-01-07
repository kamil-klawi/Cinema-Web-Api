using AutoMapper;
using Cinema.Application.Services.JwtToken;
using Cinema.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Application.User.Commands.Login;

public class LoginCommandHandler(
    ILogger<LoginCommandHandler> logger,
    SignInManager<CinemaEntities.User> signInManager,
    UserManager<CinemaEntities.User> userManager,
    IJwtTokenService jwtTokenService) : IRequestHandler<LoginCommand, string>
{
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Username);
        
        if (user == null)
            throw new NotFoundException(nameof(user), request.Username);
        
        var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);
        
        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Invalid credentials");

        var token = jwtTokenService.GenerateToken(user);
        
        return token;
    }
}