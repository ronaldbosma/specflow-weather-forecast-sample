using Microsoft.AspNetCore.Identity;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess.TestData
{
    /// <summary>
    /// Creates user setting test data
    /// </summary>
    internal class UserSettingsSeeder
    {
        private readonly WeatherForecastDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserSettingsSeeder(WeatherForecastDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void SeedData()
        {
            AddUserSettings("John", TemperatureUnit.DegreesCelsius, "Amsterdam");
            AddUserSettings("Jane", TemperatureUnit.DegreesFahrenheit, "London");

            _context.SaveChanges();
        }

        private void AddUserSettings(string username, TemperatureUnit temperatureUnit, string locationName)
        {
            var user = _userManager.FindByNameAsync(username).Result;

            var userSettingsDoNotExist = !_context.UserSettings.Any(us => us.UserId == user.Id);
            if (userSettingsDoNotExist)
            {
                var location = _context.Locations.Single(l => l.Name == locationName);

                _context.UserSettings.Add(new UserSettings
                {
                    UserId = user.Id,
                    TemperatureUnit = temperatureUnit,
                    LocationId = location.Id
                });
            }
        }
    }
}
