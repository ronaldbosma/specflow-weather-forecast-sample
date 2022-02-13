namespace WeatherForecastSample.Shared.Models
{
    public class WeatherForecastSummary
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public WeatherType WeatherType { get; set; }

        /// <summary>
        /// Gets or sets the maximum temperature in °C.
        /// </summary>
        public int MaximumTemperature { get; set; }
    }
}
