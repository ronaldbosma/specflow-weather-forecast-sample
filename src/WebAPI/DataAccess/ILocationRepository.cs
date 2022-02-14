using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
    }
}
