using Microsoft.AspNetCore.Components;
using WeatherForecastSample.Shared.Models;
using WeatherForecastSample.UI.Apis;

namespace WeatherForecastSample.UI.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IWeatherForecastApi Api { get; set; } = null!;

        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>();

        protected override async Task OnInitializedAsync()
        {
            WeatherForecasts = await Api.GetWeatherForecastForComingWeekAsync();
        }
    }
}
