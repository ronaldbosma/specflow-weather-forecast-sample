using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SolidToken.SpecFlow.DependencyInjection;
using TechTalk.SpecFlow;
using WeatherForecastSample.WebAPI;
using WeatherForecastSample.WebAPI.ApplicationLogic;
using WeatherForecastSample.WebAPI.DataAccess;

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
