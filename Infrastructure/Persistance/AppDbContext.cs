using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistance;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    internal DbSet<Restaurant> Restaurants { get; set; } = default!;
    internal DbSet<Dish> Dishes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);
    }
}
