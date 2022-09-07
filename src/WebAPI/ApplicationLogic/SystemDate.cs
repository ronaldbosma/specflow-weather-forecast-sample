namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    /// <summary>
    /// Represents the system date
    /// </summary>
    public class SystemDate : ISystemDate
    {
        /// <inheritdoc />
        public DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
    }
}
