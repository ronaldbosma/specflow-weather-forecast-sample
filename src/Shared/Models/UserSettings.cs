namespace WeatherForecastSample.Shared.Models
{
    /// <summary>
    /// Settings for a user.
    /// </summary>
    public class UserSettings
    {
        /// <summary>
        /// Gets or sets the unit in which the users wants to see the temperature displayed.
        /// </summary>
        public TemperatureUnit TemperatureUnit { get; set; }

        /// <summary>
        /// Gets or sets the id of the location for which the user wants to see the weather forecast.
        /// </summary>
        public int LocationId { get; set; }
    }
}
