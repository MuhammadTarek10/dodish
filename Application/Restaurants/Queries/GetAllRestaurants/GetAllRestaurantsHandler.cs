using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Restaurants.Queries;


public class GetAllRestaurantsHandler(
    IMapper mapper,
    IRestaurantRepository repository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{

    public async Task<IEnumerable<RestaurantDto>> Handle(
        GetAllRestaurantsQuery request,
        CancellationToken cancellationToken)
    {
        string? search = request.search?.ToLower();
        IEnumerable<Restaurant> restaurants =
            await repository.GetPagination(
                    r => search == null ||
                    (r.Name.ToLower().Contains(search) || r.Description.ToLower().Contains(search)),
                    pageSize: request.pageSize,
                    pageNumber: request.pageNumber,
                    includeProperties: "Dishes");

        IEnumerable<RestaurantDto> dtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return dtos;
    }
}

