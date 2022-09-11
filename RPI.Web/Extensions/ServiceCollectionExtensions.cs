using RPI.Web.Data;

namespace RPI.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBlazor(this IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddSingleton<WeatherForecastService>();
    }
}