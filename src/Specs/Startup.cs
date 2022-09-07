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

            // User an in memory database for WeatherForecastDbContext
            services.AddDbContext<WeatherForecastDbContext>(
                options => options.UseInMemoryDatabase("WeatherForecastSample.WeatherForecast"));

            // Register a fake system date so we can change 'today' in our tests
            var systemDate = new SystemDateFake();
            services.AddSingleton<ISystemDate>(systemDate);
            services.AddSingleton(systemDate);

            // Register a mocked authenticated user to simulate that a user is logged in
            var authenticatedUser = new Mock<IAuthenticatedUser>();
            services.AddSingleton(authenticatedUser);
            services.AddSingleton(authenticatedUser.Object);

            services.AddTransient<DataContext>();

            return services;
        }
    }
}
