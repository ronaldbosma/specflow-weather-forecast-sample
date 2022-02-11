using TechTalk.SpecFlow.Assist;

namespace WeatherForecastSample.Specs.Support
{
    internal class DateOnlyValueComparer : IValueComparer
    {
        public bool CanCompare(object actualValue)
        {
            return actualValue is DateOnly;
        }

        public bool Compare(string expectedValue, object actualValue)
        {
            var expectedDate = DateOnly.Parse(expectedValue);
            var actualDate = (DateOnly)actualValue;

            return expectedDate == actualDate;
        }
    }
}
