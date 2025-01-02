
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Restaurants.Commands;

public class CreateRestaurantCommandHandler(
    IMapper mapper,
    IRestaurantRepository repository) : IRequestHandler<CreateRestaurantCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateRestaurantCommand request,
        CancellationToken cancellationToken)
    {
        Restaurant? restaurant = mapper.Map<Restaurant>(request);
        Guid id = await repository.AddAsync(restaurant);
        return id;
    }
}
