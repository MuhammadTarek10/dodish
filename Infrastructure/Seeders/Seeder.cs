using Domain.Constants;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeders;

internal class Seeder(AppDbContext context) : ISeeder
{
    public async Task Seed()
    {
        if (context.Database.GetPendingMigrations().Any()) await context.Database.MigrateAsync();

        if (!context.Database.CanConnect()) return;

        if (!context.Restaurants.Any())
        {
            IEnumerable<Restaurant> restaurants = GetRestaurants();
            context.AddRange(restaurants);
            await context.SaveChangesAsync();
        }

        if (!context.Roles.Any())
        {
            IEnumerable<IdentityRole> roles = GetRoles();
            context.AddRange(roles);
            await context.SaveChangesAsync();
        }

    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
                [
                new (UserRoles.User)
                {
                    NormalizedName = UserRoles.User.ToUpper()
                },
                new (UserRoles.Owner)
                {
                    NormalizedName = UserRoles.Owner.ToUpper()
                },
                new (UserRoles.Admin)
                {
                    NormalizedName = UserRoles.Admin.ToUpper()
                },
            ];

        return roles;
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description =
                    "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Address = new ()
                {
                    City = "London",
                    Street = "Cork St 5",
                    PostalCode = "WC2N 5DU"
                },

            },
            new()
            {
                Name = "McDonald",
                Category = "Fast Food",
                Description =
                    "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                ContactEmail = "contact@mcdonald.com",
                HasDelivery = true,
                Address = new Address()
                {
                    City = "London",
                    Street = "Boots 193",
                    PostalCode = "W1F 8SR"
                }
            }
        ];

        return restaurants;
    }
}
