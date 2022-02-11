using WeatherForecastSample.WebAPI.Domain;

namespace WeatherForecastSample.WebAPI.BusinessLogic
{
    internal interface IWeatherForecastService
    {
        WeatherForecast GetByDate(DateOnly date);
    }
}
