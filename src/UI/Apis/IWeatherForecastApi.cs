using Refit;
using WeatherForecastSample.Shared.Models;

namespace WeatherForecastSample.UI.Apis
{
    [Headers("Content-Type: application/json")]
    public interface IWeatherForecastApi
    {
        [Get("/weatherforecasts/comingweek")]
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastForComingWeekAsync();
    }
}
