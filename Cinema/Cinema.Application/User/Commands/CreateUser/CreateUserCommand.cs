using MediatR;

namespace Cinema.Application.User.Commands.CreateUser;

public class CreateUserCommand : IRequest
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateOnly? BirthDate { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}