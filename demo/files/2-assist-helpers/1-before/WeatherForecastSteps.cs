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
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseInMemoryDatabase("WeatherForecastSample.WeatherForecast");
            _dbContext = new WeatherForecastDbContext(optionsBuilder.Options);

            _weatherForecastService = new WeatherForecastService(
                new WeatherForecastRepository(_dbContext));
        }

        [Given(@"the following weather forecasts")]
        public void GivenTheFollowingWeatherForecasts(Table table)
        {
            foreach (var row in table.Rows)
            {
                var weatherForecast = new WeatherForecast
                {
                    Date = DateTime.Parse(row["Date"]),
                    WeatherType = (WeatherType)Enum.Parse(typeof(WeatherType), row["Weather Type"]),
                    MinimumTemperature = int.Parse(row["Minimum Temperature"]),
                    MaximumTemperature = int.Parse(row["Maximum Temperature"])
                };
                _dbContext.WeatherForecasts.Add(weatherForecast);
            }
            _dbContext.SaveChanges();
        }

        [When(@"I retrieve the weather forecast for (.*)")]
        public void WhenIRetrieveTheWeatherForecastForFebruary(DateTime date)
        {
            _actualWeatherForecast = _weatherForecastService.GetByDate(date);
        }

        [Then(@"the following weather forecast is returned")]
        public void ThenTheFollowingWeatherForecastIsReturned(Table table)
        {
            var expectedWeatherForecast = table.Rows.Single();
            _actualWeatherForecast.Should().NotBeNull();
            _actualWeatherForecast!.Date.Should().Be(DateTime.Parse(expectedWeatherForecast["Date"]));
            _actualWeatherForecast!.WeatherType.Should().Be((WeatherType)Enum.Parse(typeof(WeatherType), expectedWeatherForecast["Weather Type"]));
            _actualWeatherForecast!.MinimumTemperature.Should().Be(int.Parse(expectedWeatherForecast["Minimum Temperature"]));
            _actualWeatherForecast!.MaximumTemperature.Should().Be(int.Parse(expectedWeatherForecast["Maximum Temperature"]));
        }
    }
}
