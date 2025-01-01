using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Extentions;


public static class ServiceCollectionExtensions
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString)); }

}
