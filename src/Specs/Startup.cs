using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using WeatherForecastSample.WebAPI;

namespace WeatherForecastSample.Specs
{
    [Binding]
    internal class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.AddWeatherForecastDependencies();

            // Use in memory database
            services.AddDbContext<WeatherForecastDbContext>(
                options => options.UseInMemoryDatabase("WeatherForecastSample.WeatherForecast"));

            // Mock the authenticated user
            var authenticatedUser = new Mock<IAuthenticatedUser>();
            services.AddSingleton(authenticatedUser);
            services.AddSingleton(authenticatedUser.Object);

            // Register Support classes
            services.AddTransient<DataContext>();

            return services;
        }
    }
}
