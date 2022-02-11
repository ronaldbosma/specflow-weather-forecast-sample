using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.BusinessLogic
{
    internal interface IWeatherForecastService
    {
        WeatherForecast GetByDate(DateOnly date);
    }
}
