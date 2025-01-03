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
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<RestaurantDto> restaurants = await mediator.Send(new GetAllRestaurantsQuery());

        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
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
    public async Task<IActionResult> DeleteById(Guid id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        return NoContent();
    }


    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] Guid id, UpdateRestaurantCommand command)
    {
        command.Id = id;
        await mediator.Send(command);

        return NoContent();
    }
}
