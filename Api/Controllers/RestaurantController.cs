using MediatR;
using Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Restaurants.Queries;
using Application.Restaurants.Commands;

namespace Api.Controllers;

[ApiController]
[Route("api/restaurant")]
public class RestaurantController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
    {
        IEnumerable<RestaurantDto> restaurants = await mediator.Send(new GetAllRestaurantsQuery());

        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RestaurantDto>> GetById(Guid id)
    {
        RestaurantDto restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand command)
    {
        Guid id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }



    [HttpDelete("{id}")]
    public async Task<ActionResult<RestaurantDto>> DeleteById(Guid id)
    {
        bool isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));

        if (isDeleted) return NoContent();

        return NotFound();
    }

}
