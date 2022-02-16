using TechTalk.SpecFlow.Assist;

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
        public void GivenTheFollowingWeatherForecasts(IEnumerable<WeatherForecast> weatherForecasts)
        {
            _dbContext.WeatherForecasts.AddRange(weatherForecasts);
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
            table.CompareToInstance(_actualWeatherForecast);
        }
    }
}
