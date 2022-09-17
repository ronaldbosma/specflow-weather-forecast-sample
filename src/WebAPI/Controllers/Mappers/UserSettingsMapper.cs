using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Controllers.Mappers
{
    public static class UserSettingsMapper
    {
        public static Shared.Models.UserSettings MapToModel(this UserSettings source)
        {
            return new Shared.Models.UserSettings
            {
                LocationId = source.LocationId,
                TemperatureUnit = source.TemperatureUnit.MapTo<Shared.Models.TemperatureUnit>()
            };
        }

        public static UserSettings MapToEntity(this Shared.Models.UserSettings source)
        {
            return new UserSettings
            {
                LocationId = source.LocationId,
                TemperatureUnit = source.TemperatureUnit.MapTo<TemperatureUnit>()
            };
        }
    }
}
