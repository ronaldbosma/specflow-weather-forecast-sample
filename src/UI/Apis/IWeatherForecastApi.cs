using Refit;
using WeatherForecastSample.Shared.Models;

namespace WeatherForecastSample.UI.Apis
{
    [Headers("Content-Type: application/json")]
    public interface IWeatherForecastApi
    {
        [Get("/weatherforecasts/comingweek")]
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastForComingWeekAsync();

        [Get("/weatherforecasts/date/{date}")]
        Task<WeatherForecast> GetWeatherForecastByDateAsync([Query(Format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'")] DateTime date);
    }
}
