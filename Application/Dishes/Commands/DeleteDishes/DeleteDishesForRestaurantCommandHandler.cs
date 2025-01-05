
using Domain.Constants;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Dishes.Commands;

public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantsRepository,
    IDishRepository dishesRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteDishesForRestaurantCommand>
{
    public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}", request.RestaurantId);

        var restaurant = await restaurantsRepository.GetAsync(r => r.Id == request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
            throw new ForbidException();

        foreach (var dish in restaurant.Dishes)
        {
            await dishesRepository.DeleteAsync(dish);
        }
    }
}
