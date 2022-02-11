namespace WeatherForecastSample.Shared.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public WeatherType WeatherType { get; set; }

        /// <summary>
        /// Gets or sets the minimum temperature in °C.
        /// </summary>
        public int MinimumTemperature { get; set; }

        /// <summary>
        /// Gets or sets the maximum temperature in °C.
        /// </summary>
        public int MaximumTemperature { get; set; }
    }
}
