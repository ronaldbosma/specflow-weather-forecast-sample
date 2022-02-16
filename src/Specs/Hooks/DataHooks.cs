using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;
using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.Specs.Hooks
{
    [Binding]
    internal class DataHooks
    {
        private readonly WeatherForecastDbContext _dbContext;

        public DataHooks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseInMemoryDatabase("WeatherForecastSample.WeatherForecast");
            _dbContext = new WeatherForecastDbContext(optionsBuilder.Options);

            ScenarioContext.Current.Set(_dbContext);
        }

        [BeforeScenario]
        public void InitDatabase()
        {
            _dbContext.UserSettings.RemoveRange(_dbContext.UserSettings);
            _dbContext.Users.RemoveRange(_dbContext.Users);
            _dbContext.WeatherForecasts.RemoveRange(_dbContext.WeatherForecasts);
            _dbContext.Locations.RemoveRange(_dbContext.Locations);
            _dbContext.SaveChanges();

            _dbContext.Locations.Add(new Location { Id = 1, Name = "Amsterdam" });
            _dbContext.Locations.Add(new Location { Id = 2, Name = "London" });
            _dbContext.Locations.Add(new Location { Id = 3, Name = "Madrid" });
            _dbContext.SaveChanges();
        }
    }
}
