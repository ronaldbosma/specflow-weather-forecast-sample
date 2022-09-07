namespace WeatherForecastSample.Shared.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Rounds a decimal to a whole number using the 'AwayFromZero' rounding strategy
        /// </summary>
        /// <param name="value">The value to round</param>
        /// <returns>The rounded value</returns>
        public static int RoundToWholeNumber(this decimal value)
        {
            return (int)Math.Round(value, 0, MidpointRounding.AwayFromZero);
        }
    }
}
