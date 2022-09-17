using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();

        Location GetById(int id);
    }
}
