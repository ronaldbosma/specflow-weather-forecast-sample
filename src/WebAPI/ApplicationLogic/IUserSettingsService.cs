using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    public interface IUserSettingsService
    {
        UserSettings GetUserSettingsForCurrentUser();

        void UpdateUserSettings(UserSettings newUserSettings);
    }
}
