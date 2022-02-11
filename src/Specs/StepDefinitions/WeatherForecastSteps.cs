using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using System;
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

        public WeatherForecastSteps()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>().UseInMemoryDatabase("WeatherForecast");
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
        public void WhenIRetieveTheWeatherForecastForFebruary(DateOnly date)
        {
            _actualWeatherForecast = _weatherForecastService.GetByDate(date);
        }

        [Then(@"the following weather forecast is returned")]
        public void ThenTheFollowingWeatherForecastIsReturned(Table table)
        {
            table.CompareToInstance(_actualWeatherForecast);
        }
    }
}
