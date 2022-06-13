using Refit;
using WeatherForecastSample.Shared.Models;

namespace WeatherForecastSample.UI.Apis
{
    [Headers("Content-Type: application/json", "Authorization: Bearer")]
    public interface IUserSettingsApi
    {
        [Get("/usersettings")]
        Task<UserSettings> GetUserSettingsAsync();

        [Put("/usersettings")]
        Task UpdateUserSettingsAsync([Body]UserSettings userSettings);
    }
}
