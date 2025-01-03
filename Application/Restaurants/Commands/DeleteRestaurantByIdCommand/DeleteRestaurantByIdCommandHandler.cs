using MediatR;
using Domain.Repositories;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Restaurants.Commands;

public class DeleteCommandByIdCommandHandler(
    IRestaurantRepository repository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        Restaurant? restaurant = await repository.GetAsync(r => r.Id == request.Id);

        if (restaurant is null) throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        await repository.DeleteAsync(restaurant);
    }
}

