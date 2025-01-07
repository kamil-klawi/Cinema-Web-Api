using Cinema.Domain.Constants;
using MediatR;

namespace Cinema.Application.User.Commands.UnAssignUserRole;

public class UnAssignUserRoleCommand : IRequest
{
    public string Email { get; set; } = default!;
    public Role Role { get; set; }
}