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

        [StepArgumentTransformation]
        public IEnumerable<WeatherForecast> TableToWeatherForecasts(Table table)
        {
            return table.CreateSet<WeatherForecast>();
        }
    }
}
