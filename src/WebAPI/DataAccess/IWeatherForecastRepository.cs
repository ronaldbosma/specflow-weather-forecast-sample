using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal interface IWeatherForecastRepository
    {
        WeatherForecast GetByDate(DateOnly date);

        IEnumerable<WeatherForecast> GetForComingDays(int numberOfComingDays);
    }
}
