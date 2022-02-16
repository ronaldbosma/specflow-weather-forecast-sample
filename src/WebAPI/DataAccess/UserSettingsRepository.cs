using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal class UserSettingsRepository : IUserSettingsRepository
    {
        private readonly WeatherForecastDbContext _context;

        public UserSettingsRepository(WeatherForecastDbContext context)
        {
            _context = context;
        }

        public UserSettings GetUserSettingsByUsername(string username)
        {
            var userSettings = (from u in _context.Users
                                where u.UserName == username
                                from us in _context.UserSettings
                                where us.UserId == u.Id
                                select us
                               ).SingleOrDefault();

            if (userSettings == null)
            {
                throw new ArgumentException($"No user settings found for user {username}", nameof(username));
            }
            
            return userSettings;
        }
    }
}
