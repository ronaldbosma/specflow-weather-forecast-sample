namespace WeatherForecastSample.Shared.Models
{
    public class WeatherForecastDetails
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public WeatherType WeatherType { get; set; }

        /// <summary>
        /// Gets or sets the minimum temperature in °C.
        /// </summary>
        public int MinimumTemperature { get; set; }

        /// <summary>
        /// Gets or sets the maximum temperature in °C.
        /// </summary>
        public int MaximumTemperature { get; set; }

        public decimal NumberOfMillimetresRain { get; set; }

        public int PercentageOfChanceOfRain { get; set; }

        public WindDirection WindDirection { get; set; }

        public int WindStrength { get; set; }
    }
}
