using Refit;
using WeatherForecastSample.Shared.Models;

namespace WeatherForecastSample.UI.Apis
{
    [Headers("Content-Type: application/json")]
    public interface IWeatherForecastApi
    {
        [Get("/weatherforecasts/comingweek")]
        Task<IEnumerable<WeatherForecastSummary>> GetWeatherForecastForComingWeekAsync();

        [Get("/weatherforecasts/date/{date}")]
        Task<WeatherForecastSummary> GetWeatherForecastByDateAsync([Query(Format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'")] DateTime date);
    }
}
