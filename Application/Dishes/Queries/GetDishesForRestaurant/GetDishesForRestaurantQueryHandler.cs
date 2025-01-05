using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Dishes.Queries;

public class GetDishesForRestaurantQueryHandler(ILogger<GetDishesForRestaurantQueryHandler> logger,
    IRestaurantRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving dishes for restaurant with id: {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetAsync(r => r.Id == request.RestaurantId);

        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var results = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

        return results;
    }
}
