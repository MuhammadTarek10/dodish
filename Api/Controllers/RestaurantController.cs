using MediatR;
using Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Restaurants.Queries;

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
        RestaurantDto? restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));

        if (restaurant is null) return NotFound();

        return Ok(restaurant);
    }
}
