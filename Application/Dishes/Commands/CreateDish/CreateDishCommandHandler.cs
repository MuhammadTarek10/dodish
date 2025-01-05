using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Dishes.Commands;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger,
    IRestaurantRepository restaurantsRepository,
    IDishRepository dishesRepository,
    IMapper mapper,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<CreateDishCommand, Guid>
{
    public async Task<Guid> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new dish: {@DishRequest}", request);
        var restaurant = await restaurantsRepository.GetAsync(r => r.Id == request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
            throw new ForbidException();

        var dish = mapper.Map<Dish>(request);

        return await dishesRepository.AddAsync(dish);

    }
}
