using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    public interface IUserSettingsRepository
    {
        Task<UserSettings> GetUserSettingsAsync(string userId);
    }
}
