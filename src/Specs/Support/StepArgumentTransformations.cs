using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastSample.Specs.Support
{
    [Binding]
    internal class StepArgumentTransformations
    {
        [StepArgumentTransformation("today")]
        public DateTime TodayToDateTime()
        {
            return DateTime.Today;
        }

        [StepArgumentTransformation("(.*)")]
        public DateOnly DateOnlyToDateTime(DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        [StepArgumentTransformation]
        public IEnumerable<WeatherForecast> TableToWeatherForecasts(Table table)
        {
            var weatherForecasts = table.CreateSet<Models.WeatherForecast>();
            return weatherForecasts.Select(wf => wf.ToEntity()).ToList();
        }
    }
}
