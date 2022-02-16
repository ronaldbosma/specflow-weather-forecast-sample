using Microsoft.AspNetCore.Identity;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WeatherForecastSample.WebAPI.ApplicationLogic;
using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;
using WeatherForecastSample.Specs.Support;
using Moq;

namespace WeatherForecastSample.Specs.StepDefinitions
{
    [Binding]
    internal class WeatherForecastSteps
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly WeatherForecastDbContext _dbContext;
        
        private WeatherForecast? _actualWeatherForecast;
        private List<WeatherForecast> _actualWeatherForecasts = new();

        public WeatherForecastSteps(IWeatherForecastService weatherForecastService, WeatherForecastDbContext dbContext)
        {
            _weatherForecastService = weatherForecastService;
            _dbContext = dbContext;
        }

        [Given(@"the following weather forecasts")]
        public void GivenTheFollowingWeatherForecasts(IEnumerable<WeatherForecast> weatherForecasts)
        {
            _dbContext.WeatherForecasts.AddRange(weatherForecasts);
            _dbContext.SaveChanges();
        }

        [When(@"I retrieve the weather forecast for (.*)")]
        public void WhenIRetrieveTheWeatherForecastFor(DateOnly date)
        {
            _actualWeatherForecast = _weatherForecastService.GetByDate(date);
        }

        [When(@"I retrieve the weather forecasts for the coming week")]
        public void WhenIRetrieveTheWeatherForecastsForTheComingWeek()
        {
            _actualWeatherForecasts = _weatherForecastService.GetForComingWeek().ToList();
        }

        [Then(@"the following weather forecast is returned")]
        public void ThenTheFollowingWeatherForecastIsReturned(Table expectedWeatherForecast)
        {
            expectedWeatherForecast.CompareToInstance(_actualWeatherForecast);
        }

        [Then(@"the weather forecast for '([^']*)' is returned")]
        public void ThenTheWeatherForecastForIsReturned(string expectedLocation)
        {
            var expectedLocationId = expectedLocation.GetTechnicalId();
            _actualWeatherForecast.Should().NotBeNull();
            _actualWeatherForecast!.LocationId.Should().Be(expectedLocationId);
        }

        [Then(@"the following weather forecasts are returned")]
        public void ThenTheFollowingWeatherForecastsAreReturned(Table expectedWeatherForecasts)
        {
            expectedWeatherForecasts.CompareToSet(_actualWeatherForecasts);
        }
    }
}
