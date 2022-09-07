namespace WeatherForecastSample.Specs.StepDefinitions
{
    [Binding]
    internal class WeatherForecastSteps
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly DataContext _dataContext;
        
        private WeatherForecast? _actualWeatherForecast;
        private List<WeatherForecast> _actualWeatherForecasts = new();

        public WeatherForecastSteps(IWeatherForecastService weatherForecastService, DataContext dbContext)
        {
            _weatherForecastService = weatherForecastService;
            _dataContext = dbContext;
        }

        [Given(@"the following weather forecasts")]
        public void GivenTheFollowingWeatherForecasts(IEnumerable<WeatherForecast> weatherForecasts)
        {
            _dataContext.AddWeatherForecasts(weatherForecasts);
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

        [Then(@"the weather forecast for '([^']*)' with weather type '([^']*)' is returned")]
        public void ThenTheWeatherForecastForLocationWithWeatherTypeIsReturned(string expectedLocation, WeatherType expectedWeatherType)
        {
            var expectedLocationId = expectedLocation.GetTechnicalId();
            _actualWeatherForecast.Should().NotBeNull();
            _actualWeatherForecast!.LocationId.Should().Be(expectedLocationId);
            _actualWeatherForecast!.WeatherType.Should().Be(expectedWeatherType);
        }

        [Then(@"the following weather forecasts are returned")]
        public void ThenTheFollowingWeatherForecastsAreReturned(Table expectedWeatherForecasts)
        {
            expectedWeatherForecasts.CompareToSet(_actualWeatherForecasts);
        }
    }
}
