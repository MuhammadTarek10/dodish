using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Seeders;
using Domain.Repositories;
using Infrastructure.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
using Domain.Interfaces;
using Infrastructure.Authorization.Services;

namespace Infrastructure.Extentions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(
                options => options.UseSqlite(connectionString)
                                  .EnableSensitiveDataLogging());


        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            // .AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<ISeeder, Seeder>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
        services.AddScoped<IAuthorizationHandler, CreatedMultipleRestaurantsRequirementHandler>();
        services.AddScoped<IRestaurantAuthorizationService, RestaurantAuthorizationService>();
    }

}
