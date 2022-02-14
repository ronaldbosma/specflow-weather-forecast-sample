using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Controllers.Mappers
{
    internal static class LocationMapper
    {
        public static IEnumerable<Shared.Models.Location> MapToModel(this IEnumerable<Location> source)
        {
            return source.Select(MapToModel);
        }

        public static Shared.Models.Location MapToModel(this Location source)
        {
            return new Shared.Models.Location
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }
}
