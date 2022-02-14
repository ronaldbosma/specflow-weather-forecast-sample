using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetByDate(DateOnly date);

        IEnumerable<WeatherForecast> GetForComingWeek();
    }
}
