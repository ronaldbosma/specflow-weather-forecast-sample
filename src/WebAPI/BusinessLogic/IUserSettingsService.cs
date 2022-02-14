using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.BusinessLogic
{
    public interface IUserSettingsService
    {
        Task<UserSettings> GetUserSettingsForCurrentUserAsync();
    }
}
