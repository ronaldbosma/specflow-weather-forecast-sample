namespace WeatherForecastSample.Specs.Support
{
    internal class DataContext
    {
        private readonly WeatherForecastDbContext _dbContext;

        public DataContext(WeatherForecastDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CleanDatabase()
        {
            _dbContext.UserSettings.RemoveRange(_dbContext.UserSettings);
            _dbContext.Users.RemoveRange(_dbContext.Users);
            _dbContext.WeatherForecasts.RemoveRange(_dbContext.WeatherForecasts);
            _dbContext.Locations.RemoveRange(_dbContext.Locations);
            _dbContext.SaveChanges();
        }

        public void AddWeatherForecasts(IEnumerable<WeatherForecast> weatherForecasts)
        {
            _dbContext.WeatherForecasts.AddRange(weatherForecasts);
            _dbContext.SaveChanges();
        }

        public void AddUserWithSettings(string username, TemperatureUnit temperatureUnit, int locationId)
        {
            AddUser(username);
            AddUserSettings(username, temperatureUnit, locationId);
        }

        public void AddUser(string username)
        {
            _dbContext.Users.Add(new IdentityUser(username) { Id = username });
            _dbContext.SaveChanges();
        }

        public void AddUserSettings(string username, TemperatureUnit temperatureUnit, int locationId)
        {
            _dbContext.UserSettings.Add(new UserSettings
            {
                UserId = username,
                LocationId = locationId,
                TemperatureUnit = temperatureUnit
            });
            _dbContext.SaveChanges();
        }
        
        public void AddLocations(params string[] locations)
        {
            foreach (var location in locations)
            {
                _dbContext.Locations.Add(new Location { Id = location.GetTechnicalId(), Name = location });
            }

            _dbContext.SaveChanges();
        }
    }
}
