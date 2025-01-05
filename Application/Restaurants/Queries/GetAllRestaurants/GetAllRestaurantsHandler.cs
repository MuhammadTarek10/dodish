using Application.Common;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Restaurants.Queries;


public class GetAllRestaurantsHandler(
    IMapper mapper,
    IRestaurantRepository repository) : IRequestHandler<GetAllRestaurantsQuery, PageResult<RestaurantDto>>
{

    public async Task<PageResult<RestaurantDto>> Handle(
        GetAllRestaurantsQuery request,
        CancellationToken cancellationToken)
    {
        string? search = request.search?.ToLower();
        (IEnumerable<Restaurant> restaurants, int totalCount) =
            await repository.GetPagination(
                    r => search == null ||
                    (r.Name.ToLower().Contains(search) || r.Description.ToLower().Contains(search)),
                    pageSize: request.pageSize,
                    pageNumber: request.pageNumber,
                    sortBy: request.sortBy,
                    direction: request.direction,
                    includeProperties: "Dishes");

        IEnumerable<RestaurantDto> dtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        PageResult<RestaurantDto> result = new PageResult<RestaurantDto>(
            items: dtos,
            totalCount: totalCount,
            pageSize: request.pageSize,
            pageNumber: request.pageNumber);

        return result;

    }
}


