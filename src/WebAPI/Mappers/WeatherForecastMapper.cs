using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Mappers
{
    internal static class WeatherForecastMapper
    {
        public static Shared.Models.WeatherForecast MapToModel(this WeatherForecast source)
        {
            return new Shared.Models.WeatherForecast
            {
                Id = source.Id,
                Date = source.Date,
                MaximumTemperature = source.MaximumTemperature,
                MinimumTemperature = source.MinimumTemperature,
                WeatherType = (Shared.Models.WeatherType)source.WeatherType
            };
        }
    }
}
