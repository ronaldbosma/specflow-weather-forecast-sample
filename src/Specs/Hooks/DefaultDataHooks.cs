namespace WeatherForecastSample.Specs.Hooks
{
    [Binding]
    internal class DefaultDataHooks
    {
        private readonly WeatherForecastDbContext _dbContext;
        private readonly Mock<IAuthenticatedUser> _authenticatedUserFake;

        public DefaultDataHooks(WeatherForecastDbContext dbContext, Mock<IAuthenticatedUser> mock)
        {
            _dbContext = dbContext;
            _authenticatedUserFake = mock;
        }

        [BeforeScenario(Order = 20)]
        public void CreateDefaultTestData()
        {
            // Default authenticated user with settings
            _authenticatedUserFake.Setup(u => u.GetUsername()).Returns(Default.Username);
            _dbContext.Users.Add(Default.User);
            _dbContext.UserSettings.Add(Default.UserSettings);

            // Default locations
            _dbContext.Locations.Add(new Location { Id = 1, Name = "Amsterdam" });
            _dbContext.Locations.Add(new Location { Id = 2, Name = "London" });
            _dbContext.Locations.Add(new Location { Id = 3, Name = "Madrid" });

            _dbContext.SaveChanges();
        }
    }
}
