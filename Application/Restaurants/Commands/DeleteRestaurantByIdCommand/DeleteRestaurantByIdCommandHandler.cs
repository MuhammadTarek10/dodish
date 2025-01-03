using MediatR;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Restaurants.Commands;

public class DeleteCommandByIdCommandHandler(
    IRestaurantRepository repository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        Restaurant? restaurant = await repository.GetAsync(r => r.Id == request.Id);

        if (restaurant is null) return false;

        repository.Delete(restaurant);
        return true;
    }
}

