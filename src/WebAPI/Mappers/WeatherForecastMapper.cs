using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Mappers
{
    internal static class WeatherForecastMapper
    {
        public static IEnumerable<Shared.Models.WeatherForecast> MapToModel(this IEnumerable<WeatherForecast> source)
        {
            return source.Select(s => s.MapToModel());
        }

        public static Shared.Models.WeatherForecast MapToModel(this WeatherForecast source)
        {
            return new Shared.Models.WeatherForecast
            {
                Id = source.Id,
                Date = source.Date.ToDateTime(TimeOnly.MinValue),
                MaximumTemperature = source.MaximumTemperature,
                MinimumTemperature = source.MinimumTemperature,
                WeatherType = (Shared.Models.WeatherType)source.WeatherType
            };
        }
    }
}
