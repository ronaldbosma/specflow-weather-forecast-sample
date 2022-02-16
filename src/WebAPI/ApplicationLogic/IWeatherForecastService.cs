using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetByDate(DateTime date);

        IEnumerable<WeatherForecast> GetForComingWeek();
    }
}
