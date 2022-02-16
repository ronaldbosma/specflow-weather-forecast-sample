using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    public interface IUserSettingsRepository
    {
        UserSettings GetUserSettingsByUsername(string username);

        void UpdateUserSettings(string username, UserSettings newUserSettings);
    }
}
