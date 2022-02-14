using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.Mappers
{
    internal static class LocationMapper
    {
        public static Shared.Models.Location MapToModel(this Location location)
        {
            return new Shared.Models.Location
            {
                Id = location.Id,
                Name = location.Name
            };
        }
    }
}
