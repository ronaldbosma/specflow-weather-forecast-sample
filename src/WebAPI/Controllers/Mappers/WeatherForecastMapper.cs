using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Controllers.Mappers
{
    internal static class WeatherForecastMapper
    {
        public static IEnumerable<Shared.Models.WeatherForecastSummary> MapToSummaries(this IEnumerable<WeatherForecast> source)
        {
            return source.Select(MapToSummary);
        }

        public static Shared.Models.WeatherForecastSummary MapToSummary(this WeatherForecast source)
        {
            return new Shared.Models.WeatherForecastSummary
            {
                Date = source.Date.ToDateTime(TimeOnly.MinValue),
                WeatherType = (Shared.Models.WeatherType)source.WeatherType,
                MaximumTemperature = source.MaximumTemperature
            };
        }

        public static Shared.Models.WeatherForecastDetails MapToDetails(this WeatherForecast source)
        {
            return new Shared.Models.WeatherForecastDetails
            {
                Id = source.Id,
                LocationId = source.LocationId,
                Date = source.Date.ToDateTime(TimeOnly.MinValue),
                WeatherType = (Shared.Models.WeatherType)source.WeatherType,
                MaximumTemperature = source.MaximumTemperature,
                MinimumTemperature = source.MinimumTemperature,
                NumberOfMillimetresRain = source.NumberOfMillimetresRain,
                PercentageOfChanceOfRain = source.PercentageOfChanceOfRain,
                WindDirection = (Shared.Models.WindDirection)source.WindDirection,
                WindStrength = source.WindStrength
            };
        }
    }
}
