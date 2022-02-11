using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.BusinessLogic
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetByDate(DateOnly date);
    }
}
