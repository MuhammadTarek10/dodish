using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories;

internal class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(AppDbContext context) : base(context) { }
}
