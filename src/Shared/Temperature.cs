using WeatherForecastSample.Shared.Extensions;
using WeatherForecastSample.Shared.Models;

namespace WeatherForecastSample.Shared
{
    public record Temperature
    {
        private Temperature(int degreesCelsius, int degreesFahrenheit)
        {
            DegreesCelsius = degreesCelsius;
            DegreesFahrenheit = degreesFahrenheit;
        }

        public int DegreesCelsius { get; init; }

        public int DegreesFahrenheit { get; init; }

        public string ToString(TemperatureUnit temperatureUnit)
        {
            return temperatureUnit == TemperatureUnit.DegreesCelsius ? $"{DegreesCelsius} °C" : $"{DegreesFahrenheit} °F";
        }

        public static Temperature FromDegreesCelsius(int degreesCelsius)
        {
            throw new NotImplementedException();
        }
    }
}
