namespace WeatherForecastSample.Specs.Support
{
    /// <summary>
    /// Fake system date that can be used to change the current date
    /// </summary>
    internal class SystemDateFake : ISystemDate
    {
        /// <inheritdoc />
        public DateOnly Today { get; set; }

        /// <summary>
        /// Resets the system date to the actual current date
        /// </summary>
        public void Reset()
        {
            Today = DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
