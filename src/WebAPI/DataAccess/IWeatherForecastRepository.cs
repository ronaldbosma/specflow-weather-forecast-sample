using WeatherForecastSample.WebAPI.Domain;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal interface IWeatherForecastRepository
    {
        WeatherForecast GetByDate(DateOnly date);
    }
}
