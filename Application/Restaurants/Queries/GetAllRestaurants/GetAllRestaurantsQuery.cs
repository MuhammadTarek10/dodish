using Application.Dtos;
using Domain.Constants;
using MediatR;

namespace Application.Restaurants.Queries;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
    public string? search { get; set; }
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public string? sortBy { get; set; }
    public SortDirection direction { get; set; }
}
