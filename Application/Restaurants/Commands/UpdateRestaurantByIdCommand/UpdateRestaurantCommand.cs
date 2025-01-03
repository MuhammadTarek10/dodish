using MediatR;

namespace Application.Restaurants.Commands;

public class UpdateRestaurantCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool HasDelivery { get; set; }
}
