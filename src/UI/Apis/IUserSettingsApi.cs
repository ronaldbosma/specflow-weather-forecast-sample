using Refit;
using WeatherForecastSample.Shared.Models;

namespace WeatherForecastSample.UI.Apis
{
    [Headers("Content-Type: application/json")]
    public interface IUserSettingsApi
    {
        [Get("/usersettings")]
        Task<UserSettings> GetUserSettingsAsync();
    }
}
