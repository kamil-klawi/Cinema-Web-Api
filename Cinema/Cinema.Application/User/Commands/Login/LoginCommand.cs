using MediatR;

namespace Cinema.Application.User.Commands.Login;

public class LoginCommand : IRequest<string>
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}