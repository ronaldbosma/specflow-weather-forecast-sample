namespace WeatherForecastSample.Specs.Support
{
    [Binding]
    internal class StepArgumentTransformations
    {
        private readonly SystemDateFake _systemDate;

        public StepArgumentTransformations(SystemDateFake systemDate)
        {
            _systemDate = systemDate;
        }

        [StepArgumentTransformation("today")]
        public DateTime TransformDateTimeToDate()
        {
            return _systemDate.Today.ToDateTime(TimeOnly.MinValue);
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
