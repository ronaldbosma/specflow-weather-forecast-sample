namespace WeatherForecastSample.Specs.Support
{
    internal class DataContext
    {
        public DataContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseInMemoryDatabase("WeatherForecastSample.WeatherForecast");
            DbContext = new WeatherForecastDbContext(optionsBuilder.Options);

            ScenarioContext.Current.Set(this);
        }

        public WeatherForecastDbContext DbContext { get; }

        public void CleanDatabase()
        {
            DbContext.UserSettings.RemoveRange(DbContext.UserSettings);
            DbContext.Users.RemoveRange(DbContext.Users);
            DbContext.WeatherForecasts.RemoveRange(DbContext.WeatherForecasts);
            DbContext.Locations.RemoveRange(DbContext.Locations);
            DbContext.SaveChanges();
        }

        public void AddWeatherForecasts(IEnumerable<WeatherForecast> weatherForecasts)
        {
            DbContext.WeatherForecasts.AddRange(weatherForecasts);
            DbContext.SaveChanges();
        }

        public void AddUserWithSettings(string username, TemperatureUnit temperatureUnit, int locationId)
        {
            AddUser(username);
            AddUserSettings(username, temperatureUnit, locationId);
        }

        public void AddUser(string username)
        {
            DbContext.Users.Add(new IdentityUser(username) { Id = username });
            DbContext.SaveChanges();
        }

        public void AddUserSettings(string username, TemperatureUnit temperatureUnit, int locationId)
        {
            DbContext.UserSettings.Add(new UserSettings
            {
                UserId = username,
                LocationId = locationId,
                TemperatureUnit = temperatureUnit
            });
            DbContext.SaveChanges();
        }
        
        public void AddLocations(params string[] locations)
        {
            foreach (var location in locations)
            {
                DbContext.Locations.Add(new Location { Id = location.GetTechnicalId(), Name = location });
            }

            DbContext.SaveChanges();
        }
    }
}
