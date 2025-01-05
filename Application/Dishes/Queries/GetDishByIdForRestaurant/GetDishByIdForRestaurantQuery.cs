using Application.Dtos;
using MediatR;

namespace Application.Dishes.Queries;

public class GetDishByIdForRestaurantQuery(Guid restaurantId, Guid dishId) : IRequest<DishDto>
{
    public Guid RestaurantId { get; } = restaurantId;
    public Guid DishId { get; } = dishId;
}
