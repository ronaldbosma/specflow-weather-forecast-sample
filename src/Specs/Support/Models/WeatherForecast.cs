using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.Specs.Support.Models
{
    internal class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public WeatherType WeatherType { get; set; }

        public int MinimumTemperature { get; set; }

        public int MaximumTemperature { get; set; }

        public decimal NumberOfMillimetresRain { get; set; }

        public int PercentageOfChanceOfRain { get; set; }

        public WindDirection WindDirection { get; set; }

        public int WindStrength { get; set; }

        public string Location { get; set; } = Default.Location;

        public int LocationId => Location.GetTechnicalId();

        public WebAPI.Entities.WeatherForecast ToEntity()
        {
            return new WebAPI.Entities.WeatherForecast
            {
                Date = Date,
                WeatherType = WeatherType,
                MinimumTemperature = MinimumTemperature,
                MaximumTemperature = MaximumTemperature,
                NumberOfMillimetresRain = NumberOfMillimetresRain,
                PercentageOfChanceOfRain = PercentageOfChanceOfRain,
                WindDirection = WindDirection,
                WindStrength = WindStrength,
                LocationId = LocationId,
            };
        }
    }
}
