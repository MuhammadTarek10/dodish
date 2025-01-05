
using Application.Dishes.Queries;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetDishByIdForRestaurantQueryHandler(
    ILogger<GetDishByIdForRestaurantQueryHandler> logger,
    IRestaurantRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving dish: {DishId}, for restaurant with id: {RestaurantId}",
            request.DishId,
            request.RestaurantId);

        var restaurant = await restaurantsRepository.GetAsync(r => r.Id == request.RestaurantId);

        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
        if (dish == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());

        var result = mapper.Map<DishDto>(dish);
        return result;
    }
}
