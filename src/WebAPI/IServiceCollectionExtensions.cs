using Microsoft.EntityFrameworkCore;
using WeatherForecastSample.WebAPI.BusinessLogic;
using WeatherForecastSample.WebAPI.DataAccess;

namespace WeatherForecastSample.WebAPI
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherForecastDependencies(this IServiceCollection services)
        {
            return services
                .AddTransient<IWeatherForecastService, WeatherForecastService>()
                .AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
        }

        public static IServiceCollection AddWeatherForecastDbContext(this IServiceCollection services)
        {
            return services.AddDbContext<WeatherForecastDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:WeatherForecastDatabase"));
        }

        public static IServiceCollection EnsureDatabaseExists(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetRequiredService<WeatherForecastDbContext>();
            context.Database.EnsureCreated();

            return services;
        }
    }
}
