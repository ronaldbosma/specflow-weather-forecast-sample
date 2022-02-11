using TechTalk.SpecFlow;

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
    }
}
