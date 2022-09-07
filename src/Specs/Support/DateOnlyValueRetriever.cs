namespace WeatherForecastSample.Specs.Support
{
    /// <summary>
    /// Value Retriever that can be used by Table Assist Helpers to convert a value to type <see cref="DateOnly"/>.
    /// </summary>
    internal class DateOnlyValueRetriever : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType == typeof(DateOnly);
        }

        public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return DateOnly.Parse(keyValuePair.Value);
        }
    }
}
