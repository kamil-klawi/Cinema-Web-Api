using Cinema.Application.Cinema.Commands.CreateCinema;
using Cinema.Application.Cinema.Commands.DeleteCinema;
using Cinema.Application.Cinema.Commands.UpdateCinema;
using Cinema.Application.Cinema.Dtos;
using Cinema.Application.Cinema.Queries.GetAllCinemas;
using Cinema.Application.Cinema.Queries.GetCinemaById;
using Cinema.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CinemaController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CinemaDto>>> GetAllCinemasCinema([FromQuery] GetAllCinemasQuery query)
    {
        var cinemas = await mediator.Send(query);
        return Ok(cinemas);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CinemaDto?>> GetCinemaById([FromRoute] int id)
    {
        var cinema = await mediator.Send(new GetCinemaByIdQuery(id));
        return Ok(cinema);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> CreateCinema([FromBody] CreateCinemaCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetCinemaById), new { id }, null);
    }
    
    [HttpPatch("{id:int}")]
    [Authorize(Roles = nameof(Role.ADMIN))]
    public async Task<ActionResult> UpdateCinema([FromRoute] int id, UpdateCinemaCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    [Authorize(Roles = nameof(Role.ADMIN))]
    public async Task<ActionResult> DeleteCinema([FromRoute] int id)
    {
        await mediator.Send(new DeleteCinemaCommand(id));
        return NoContent();
    }
}