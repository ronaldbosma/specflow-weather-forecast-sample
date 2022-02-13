using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WeatherForecastSample.Shared.Models;
using WeatherForecastSample.UI.Apis;

namespace WeatherForecastSample.UI.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IWeatherForecastApi Api { get; set; } = null!;

        public IEnumerable<WeatherForecastSummary> WeatherForecasts { get; set; } = new List<WeatherForecastSummary>();

        public WeatherForecastSummary? SelectedWeatherForecast { get; set; }

        protected override async Task OnInitializedAsync()
        {
            WeatherForecasts = (await Api.GetWeatherForecastForComingWeekAsync()).OrderBy(wf => wf.Date);

            if (WeatherForecasts.Any())
            {
                await SelectWeatherForecastAsync(WeatherForecasts.First().Date);
            }
        }

        public async Task SelectWeatherForecastAsync(DateTime selectedDate)
        {
            SelectedWeatherForecast = await Api.GetWeatherForecastByDateAsync(selectedDate);
        }
    }
}
