namespace WeatherForecastSample.Specs.Hooks
{
    [Binding]
    internal class DatabaseHooks
    {
        private readonly WeatherForecastDbContext _dbContext;

        public DatabaseHooks(WeatherForecastDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BeforeScenario(Order = 10)]
        public void CleanDatabase()
        {
            _dbContext.UserSettings.RemoveRange(_dbContext.UserSettings);
            _dbContext.Users.RemoveRange(_dbContext.Users);
            _dbContext.WeatherForecasts.RemoveRange(_dbContext.WeatherForecasts);
            _dbContext.Locations.RemoveRange(_dbContext.Locations);
            _dbContext.SaveChanges();
        }
    }
}
