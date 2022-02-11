using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WeatherForecastSample.UI.Apis;

namespace WeatherForecastSample.UI.Pages
{
    public class FetchDataBase : ComponentBase
    {
        public WeatherForecast[]? forecasts;

        [Inject]
        public HttpClient Http { get; set; } = null!;

        [Inject]
        public IWeatherForecastApi Api { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            try
            {
                var tmp = await Api.GetWeatherForecastForComingWeekAsync();

                forecasts = tmp.Select(t => new WeatherForecast
                {
                    Date = t.Date,
                    Summary = t.WeatherType.ToString(),
                    TemperatureC = t.MinimumTemperature
                }).ToArray();

                //forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public string? Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
