using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WeatherForecastSample.WebAPI.BusinessLogic;
using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.Specs.StepDefinitions
{
    [Binding]
    internal class WeatherForecastSteps
    {
        private readonly WeatherForecastService _weatherForecastService;
        private readonly WeatherForecastDbContext _dbContext;
        
        private WeatherForecast? _actualWeatherForecast;
        private List<WeatherForecast> _actualWeatherForecasts = new();

        public WeatherForecastSteps()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseInMemoryDatabase("WeatherForecastSample.WeatherForecast");
            _dbContext = new WeatherForecastDbContext(optionsBuilder.Options);

            _weatherForecastService = new WeatherForecastService(
                new WeatherForecastRepository(_dbContext));
        }

        [BeforeScenario]
        public void CleanDatabase()
        {
            _dbContext.WeatherForecasts.RemoveRange(_dbContext.WeatherForecasts);
            _dbContext.SaveChanges();
        }

        [Given(@"the following weather forecasts")]
        public void GivenTheFollowingWeatherForecasts(Table table)
        {
            var weatherForecasts = table.CreateSet<WeatherForecast>();
            _dbContext.WeatherForecasts.AddRange(weatherForecasts);
            _dbContext.SaveChanges();
        }

        [When(@"I retieve the weather forecast for (.*)")]
        public void WhenIRetieveTheWeatherForecastFor(DateOnly date)
        {
            _actualWeatherForecast = _weatherForecastService.GetByDate(date);
        }

        [When(@"I retieve the weather forecasts for the coming week")]
        public void WhenIRetieveTheWeatherForecastsForTheComingWeek()
        {
            _actualWeatherForecasts = _weatherForecastService.GetForComingWeek().ToList();
        }

        [Then(@"the following weather forecast is returned")]
        public void ThenTheFollowingWeatherForecastIsReturned(Table expectedWeatherForecast)
        {
            expectedWeatherForecast.CompareToInstance(_actualWeatherForecast);
        }

        [Then(@"the following weather forecasts are returned")]
        public void ThenTheFollowingWeatherForecastsAreReturned(Table expectedWeatherForecasts)
        {
            expectedWeatherForecasts.CompareToSet(_actualWeatherForecasts);
        }
    }
}
