using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Restaurants.Commands;

public class UpdateRestaurantCommandHandler(
        ILogger<UpdateRestaurantCommandHandler> logger,
        IMapper mapper,
        IRestaurantRepository repository,
        IRestaurantAuthorizationService service) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(
        UpdateRestaurantCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id: {RestaurantId} with {@UpdatedRestaurant}", request.Id, request);

        Restaurant? restaurant = await repository.GetAsync(r => r.Id == request.Id);

        if (restaurant is null) throw new NotFoundException(nameof(Restaurant), request.Id.ToString());


        if (!service.Authorize(restaurant, ResourceOperation.Update)) throw new ForbidException();

        Restaurant UpdatedRestaurant = mapper.Map(request, restaurant);

        await repository.UpdateAsync(UpdatedRestaurant);
    }
}
