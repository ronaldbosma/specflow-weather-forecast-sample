using BoDi;
using Microsoft.EntityFrameworkCore;
using Moq;
using TechTalk.SpecFlow;
using WeatherForecastSample.WebAPI.ApplicationLogic;
using WeatherForecastSample.WebAPI.DataAccess;

namespace WeatherForecastSample.Specs
{
    [Binding]
    internal class Startup
    {
        private readonly IObjectContainer _container;

        public Startup(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario(Order = 0)]
        public void RegisterDependencies()
        {
            var authenticatedUser = new Mock<IAuthenticatedUser>();
            _container.RegisterInstanceAs(authenticatedUser);
            _container.RegisterInstanceAs(authenticatedUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseInMemoryDatabase("WeatherForecastSample.WeatherForecast");
            var dbContext = new WeatherForecastDbContext(optionsBuilder.Options);
            _container.RegisterInstanceAs(dbContext);

            _container.RegisterTypeAs<LocationRepository, ILocationRepository>();
            _container.RegisterTypeAs<UserSettingsRepository, IUserSettingsRepository>();
            _container.RegisterTypeAs<UserSettingsService, IUserSettingsService>();
            _container.RegisterTypeAs<WeatherForecastService, IWeatherForecastService>();
            _container.RegisterTypeAs<WeatherForecastRepository, IWeatherForecastRepository>();
        }
    }
}
