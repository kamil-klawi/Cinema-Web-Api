using Cinema.Domain.Constants;
using MediatR;

namespace Cinema.Application.User.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public string Email { get; set; } = default!;
    public Role Role { get; set; }
}