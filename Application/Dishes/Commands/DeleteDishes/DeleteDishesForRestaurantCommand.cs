using MediatR;

namespace Application.Dishes.Commands;

public class DeleteDishesForRestaurantCommand(Guid restaurantId) : IRequest
{
    public Guid RestaurantId { get; } = restaurantId;
}
