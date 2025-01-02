using Application.Dtos;
using MediatR;

namespace Application.Restaurants.Queries;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}
