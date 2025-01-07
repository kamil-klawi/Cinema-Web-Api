using MediatR;

namespace Cinema.Application.User.Commands.DeleteUser;

public class DeleteUserCommand(string id) : IRequest
{
    public string Id { get; } = id;
}