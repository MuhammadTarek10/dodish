using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Exceptions;
using MediatR;


namespace Application.Restaurants.Queries;

public class GetRestaurantByIdHandler(
    IMapper mapper,
    IRestaurantRepository repository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(
        GetRestaurantByIdQuery request,
        CancellationToken cancellationToken)
    {
        Restaurant restaurant = await repository.GetAsync(u => u.Id == request.Id, includeProperties: "Dishes") ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        RestaurantDto dto = mapper.Map<RestaurantDto>(restaurant);

        return dto;
    }
}
