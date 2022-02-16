namespace WeatherForecastSample.Specs.Hooks
{
    [Binding]
    internal class DefaultDataHooks
    {
        private readonly DataContext _dataContext;
        private readonly Mock<IAuthenticatedUser> _authenticatedUserFake;

        public DefaultDataHooks(DataContext dataContext, Mock<IAuthenticatedUser> mock)
        {
            _dataContext = dataContext;
            _authenticatedUserFake = mock;
        }

        [BeforeScenario(Order = 20)]
        public void CreateDefaultTestData()
        {
            _authenticatedUserFake.Setup(u => u.GetUsername()).Returns(Default.Username);
            _dataContext.AddUserWithSettings(Default.Username, TemperatureUnit.DegreesCelsius, Default.LocationId);
            _dataContext.AddLocations("Amsterdam", "London", "Madrid");
        }
    }
}
