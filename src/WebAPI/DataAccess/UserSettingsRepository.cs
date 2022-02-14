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

        public async Task<UserSettings> GetUserSettingsAsync(string userId)
        {
            var userSettings = await _context.UserSettings.FindAsync(userId);

            if (userSettings == null)
            {
                throw new ArgumentException($"No user settings found for user with id {userId}", nameof(userId));
            }
            
            return userSettings;
        }
    }
}
