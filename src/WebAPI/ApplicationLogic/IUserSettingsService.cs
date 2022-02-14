using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    public interface IUserSettingsService
    {
        Task<UserSettings> GetUserSettingsForCurrentUserAsync();
    }
}
