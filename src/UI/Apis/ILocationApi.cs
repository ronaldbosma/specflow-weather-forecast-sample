using Refit;
using WeatherForecastSample.Shared.Models;

namespace WeatherForecastSample.UI.Apis
{
    [Headers("Content-Type: application/json", "Authorization: Bearer")]
    public interface ILocationApi
    {
        [Get("/locations")]
        Task<IEnumerable<Location>> GetLocationsAsync();

        [Get("/locations/{id}")]
        Task<Location> GetLocationByIdAsync(int id);
    }
}
