namespace Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
    }
}
