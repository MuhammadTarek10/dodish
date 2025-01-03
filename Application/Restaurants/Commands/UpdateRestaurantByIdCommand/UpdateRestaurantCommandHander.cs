using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Restaurants.Commands;

public class UpdateRestaurantCommandHandler(
        IRestaurantRepository repository) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(
        UpdateRestaurantCommand request,
        CancellationToken cancellationToken)
    {
        Restaurant? restaurant = await repository.GetAsync(r => r.Id == request.Id);

        if (restaurant is null) return false;

        await repository.UpdateAsync(restaurant);
        return true;
    }
}
