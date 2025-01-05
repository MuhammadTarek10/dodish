using Application.Dishes.Commands;
using Application.Dishes.Queries;
using Application.Dtos;
using Infrastructure.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
[Authorize]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] Guid restaurantId, CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;

        var dishId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId, dishId }, null);
    }

    [HttpGet]
    [Authorize(Policy = PolicyNames.AtLeast20)]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] Guid restaurantId)
    {
        var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] Guid restaurantId, [FromRoute] Guid dishId)
    {
        var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
        return Ok(dish);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDishesForRestaurant([FromRoute] Guid restaurantId)
    {
        await mediator.Send(new DeleteDishesForRestaurantCommand(restaurantId));
        return NoContent();
    }
}
