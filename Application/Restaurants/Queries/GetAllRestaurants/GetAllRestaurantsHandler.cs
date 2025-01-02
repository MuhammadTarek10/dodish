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
        IEnumerable<Restaurant> restaurants = await repository.GetAllAsync(includeProperties: "Dishes");

        IEnumerable<RestaurantDto> dtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return dtos;
    }
}

