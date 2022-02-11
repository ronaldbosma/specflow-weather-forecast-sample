namespace WeatherForecastSample.Shared.Extensions
{
    public static class DecimalExtensions
    {
        public static int RoundToWholeNumber(this decimal value)
        {
            return (int)Math.Round(value, 0, MidpointRounding.AwayFromZero);
        }
    }
}
