namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    /// <summary>
    /// Represents the system date
    /// </summary>
    /// <remarks>
    /// This interface makes it possible to change the system date during test automation
    /// </remarks>
    internal interface ISystemDate
    {
        /// <summary>
        /// Get the current date
        /// </summary>
        DateOnly Today { get; }
    }
}
