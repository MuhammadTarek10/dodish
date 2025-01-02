using MediatR;
using Application.Dtos;

namespace Application.Restaurants.Queries;

public class GetRestaurantByIdQuery(Guid id) : IRequest<RestaurantDto>
{
    public Guid Id { get; } = id;
}
