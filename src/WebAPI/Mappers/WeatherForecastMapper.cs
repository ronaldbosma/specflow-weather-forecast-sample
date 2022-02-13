using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Mappers
{
    internal static class WeatherForecastMapper
    {
        public static IEnumerable<Shared.Models.WeatherForecastSummary> MapToSummaries(this IEnumerable<WeatherForecast> source)
        {
            return source.Select(s => s.MapToSummary());
        }

        public static Shared.Models.WeatherForecastSummary MapToSummary(this WeatherForecast source)
        {
            return new Shared.Models.WeatherForecastSummary
            {
                Date = source.Date.ToDateTime(TimeOnly.MinValue),
                MaximumTemperature = source.MaximumTemperature,
                WeatherType = (Shared.Models.WeatherType)source.WeatherType
            };
        }
    }
}
