using MediatR;

namespace Application.Restaurants.Commands;

public class DeleteRestaurantCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}
