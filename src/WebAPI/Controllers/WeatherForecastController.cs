using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastSample.Shared.Models;
using WeatherForecastSample.WebAPI.BusinessLogic;
using WeatherForecastSample.WebAPI.Controllers.Mappers;

namespace WeatherForecastSample.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("/api/weatherforecasts/comingweek")]
        public IEnumerable<WeatherForecastSummary> GetWeatherForcastForComingWeek()
        {
            var weatherForecasts = _weatherForecastService.GetForComingWeek();
            return weatherForecasts.MapToSummaries();
        }

        [HttpGet("/api/weatherforecasts/date/{date}")]
        public WeatherForecastDetails GetWeatherForecastByDate(DateTime date)
        {
            var weatherForecast = _weatherForecastService.GetByDate(DateOnly.FromDateTime(date));
            return weatherForecast.MapToDetails();
        }
    }
}