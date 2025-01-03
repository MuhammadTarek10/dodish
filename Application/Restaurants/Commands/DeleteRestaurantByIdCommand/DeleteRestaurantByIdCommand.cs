using MediatR;

namespace Application.Restaurants.Commands;

public class DeleteRestaurantCommand(Guid id) : IRequest<bool>
{
    public Guid Id { get; } = id;
}
