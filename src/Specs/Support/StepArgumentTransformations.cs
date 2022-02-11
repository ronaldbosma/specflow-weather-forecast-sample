using TechTalk.SpecFlow;

namespace WeatherForecastSample.Specs.Support
{
    [Binding]
    internal class StepArgumentTransformations
    {
        [StepArgumentTransformation("(.*)")]
        public DateOnly TransformDateTimeToDate(DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }
    }
}
