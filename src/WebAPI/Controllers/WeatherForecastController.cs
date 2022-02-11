using Microsoft.AspNetCore.Mvc;
using WeatherForecastSample.Shared.Models;
using WeatherForecastSample.WebAPI.BusinessLogic;
using WeatherForecastSample.WebAPI.Mappers;

namespace WeatherForecastSample.WebAPI.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("/weatherforecasts/comingweek")]
        public IEnumerable<WeatherForecast> GetWeatherForcastForComingWeek()
        {
            var weatherForecasts = _weatherForecastService.GetForComingWeek();
            return weatherForecasts.MapToModel();
        }

        [HttpGet("/weatherforecasts/date/{date}")]
        public WeatherForecast GetWeatherForecastByDate(DateTime date)
        {
            var weatherForecast = _weatherForecastService.GetByDate(DateOnly.FromDateTime(date));
            return weatherForecast.MapToModel();
        }
    }
}