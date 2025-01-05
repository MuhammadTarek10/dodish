using Application.Dtos;
using MediatR;

namespace Application.Dishes.Queries;

public class GetDishesForRestaurantQuery(Guid restaurantId) : IRequest<IEnumerable<DishDto>>
{
    public Guid RestaurantId { get; } = restaurantId;
}
