using MediatR;

namespace Cinema.Application.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly? BirthDate { get; set; }
}