using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite(
                builder
                .Configuration
                .GetConnectionString("DefaultConnection")
));


builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
