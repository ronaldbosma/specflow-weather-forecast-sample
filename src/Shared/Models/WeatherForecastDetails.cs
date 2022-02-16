namespace WeatherForecastSample.Shared.Models
{
    public class WeatherForecastDetails
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public WeatherType WeatherType { get; set; }

        public int MinimumTemperature { get; set; }

        public int MaximumTemperature { get; set; }

        public decimal NumberOfMillimetresRain { get; set; }

        public int PercentageOfChanceOfRain { get; set; }

        public WindDirection WindDirection { get; set; }

        public int WindStrength { get; set; }
    }
}
