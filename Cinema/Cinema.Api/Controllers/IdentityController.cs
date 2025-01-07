using Cinema.Application.User.Commands.AssignUserRole;
using Cinema.Application.User.Commands.CreateUser;
using Cinema.Application.User.Commands.DeleteUser;
using Cinema.Application.User.Commands.Login;
using Cinema.Application.User.Commands.UnAssignUserRole;
using Cinema.Application.User.Commands.UpdateUser;
using Cinema.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginCommand command)
    {
        var token = await mediator.Send(command);
        return Ok(new { Token = token });
    }
    
    [HttpPatch("user/{userId}")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("user/{userId}")]
    [Authorize(Roles = nameof(Role.ADMIN))]
    public async Task<IActionResult> DeleteUser([FromRoute] string userId)
    {
        await mediator.Send(new DeleteUserCommand(userId));
        return NoContent();
    }
    
    [HttpPatch("user/{userId}/role")]
    [Authorize(Roles = nameof(Role.ADMIN))]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("user/{userId}/role")]
    [Authorize(Roles = nameof(Role.ADMIN))]
    public async Task<IActionResult> UnAssignUserRole(UnAssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}