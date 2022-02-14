using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Mappers
{
    public static class UserSettingsMapper
    {
        public static Shared.Models.UserSettings ToModel(this UserSettings userSettings)
        {
            return new Shared.Models.UserSettings
            {
                LocationId = userSettings.LocationId,
                TemperatureUnit = (Shared.Models.TemperatureUnit)userSettings.TemperatureUnit
            };
        }
    }
}
