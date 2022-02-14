using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Mappers
{
    public static class UserSettingsMapper
    {
        public static Shared.Models.UserSettings ToModel(this UserSettings source)
        {
            return new Shared.Models.UserSettings
            {
                LocationId = source.LocationId,
                TemperatureUnit = (Shared.Models.TemperatureUnit)source.TemperatureUnit
            };
        }
    }
}
