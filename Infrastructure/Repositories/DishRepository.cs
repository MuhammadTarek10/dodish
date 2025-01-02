using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories;

internal class DishRepository : Repository<Dish>, IDishRepository
{
    public DishRepository(AppDbContext context) : base(context) { }
}
