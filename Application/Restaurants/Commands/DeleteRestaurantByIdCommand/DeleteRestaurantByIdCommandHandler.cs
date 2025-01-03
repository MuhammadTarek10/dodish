using MediatR;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Restaurants.Commands;

public class DeleteCommandByIdCommandHandler(
    IRestaurantRepository repository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        Restaurant? restaurant = await repository.GetAsync(r => r.Id == request.Id);

        if (restaurant is null) throw new Exception("Not Found");

        await repository.DeleteAsync(restaurant);
    }
}

