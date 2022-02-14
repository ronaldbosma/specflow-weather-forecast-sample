using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Mappers
{
    public static class UserSettingsMapper
    {
        public static Shared.Models.UserSettings MapToModel(this UserSettings source)
        {
            return new Shared.Models.UserSettings
            {
                LocationId = source.LocationId,
                TemperatureUnit = (Shared.Models.TemperatureUnit)source.TemperatureUnit
            };
        }
    }
}
