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
        public IEnumerable<WeatherForecastSummary> GetWeatherForcastForComingWeek()
        {
            var weatherForecasts = _weatherForecastService.GetForComingWeek();
            return weatherForecasts.MapToSummaries();
        }

        [HttpGet("/weatherforecasts/date/{date}")]
        public WeatherForecastDetails GetWeatherForecastByDate(DateTime date)
        {
            var weatherForecast = _weatherForecastService.GetByDate(DateOnly.FromDateTime(date));
            return weatherForecast.MapToDetails();
        }
    }
}