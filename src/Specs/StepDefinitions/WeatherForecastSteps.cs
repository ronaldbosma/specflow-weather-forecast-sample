using TechTalk.SpecFlow.Assist;

namespace WeatherForecastSample.Specs.StepDefinitions
{
    [Binding]
    internal class WeatherForecastSteps
    {
        private readonly WeatherForecastService _weatherForecastService;
        private readonly DataContext _dataContext;

        private WeatherForecast? _actualWeatherForecast;

        public WeatherForecastSteps()
        {
            _dataContext = ScenarioContext.Current.Get<DataContext>();
            var authenticatedUserFake = ScenarioContext.Current.Get<Mock<IAuthenticatedUser>>();

            _weatherForecastService = new WeatherForecastService(
                new WeatherForecastRepository(_dataContext.DbContext),
                new UserSettingsService(authenticatedUserFake.Object, new UserSettingsRepository(_dataContext.DbContext)));
        }

        [Given(@"the following weather forecasts")]
        public void GivenTheFollowingWeatherForecasts(IEnumerable<WeatherForecast> weatherForecasts)
        {
            _dataContext.AddWeatherForecasts(weatherForecasts);
        }

        [When(@"I retrieve the weather forecast for (.*)")]
        public void WhenIRetrieveTheWeatherForecastForFebruary(DateOnly date)
        {
            _actualWeatherForecast = _weatherForecastService.GetByDate(date);
        }

        [Then(@"the following weather forecast is returned")]
        public void ThenTheFollowingWeatherForecastIsReturned(Table table)
        {
            table.CompareToInstance(_actualWeatherForecast);
        }

        [Then(@"the weather forecast for '([^']*)' is returned")]
        public void ThenTheWeatherForecastForIsReturned(string expectedLocation)
        {
            var expectedLocationId = expectedLocation.GetTechnicalId();
            _actualWeatherForecast.Should().NotBeNull();
            _actualWeatherForecast!.LocationId.Should().Be(expectedLocationId);
        }
    }
}
