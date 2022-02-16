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
            services.AddDbContext<WeatherForecastDbContext>(
                options => options.UseInMemoryDatabase("WeatherForecastSample.WeatherForecast"));

            var authenticatedUser = new Mock<IAuthenticatedUser>();
            services.AddSingleton(authenticatedUser);
            services.AddSingleton(authenticatedUser.Object);

            return services;
        }
    }
}
