namespace WeatherForecastSample.Specs.Support
{
    /// <summary>
    /// Value Comparer that can be used by Table Assist Helpers to compare a value of type <see cref="DateOnly"/>.
    /// </summary>
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
