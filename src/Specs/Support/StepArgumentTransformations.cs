using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.Specs.Support
{
    [Binding]
    internal class StepArgumentTransformations
    {
        [StepArgumentTransformation("today")]
        public DateTime TransformDateTimeToDate()
        {
            return DateTime.Today;
        }

        [StepArgumentTransformation("(.*)")]
        public DateOnly TransformDateTimeToDate(DateTime dateTime)
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
