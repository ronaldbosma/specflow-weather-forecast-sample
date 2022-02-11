using WeatherForecastSample.Shared.Extensions;

namespace WeatherForecastSample.WebAPI.Entities
{
    internal record Temperature
    {
        private Temperature(int degreesCelsius, int degreesFahrenheit)
        {
            DegreesCelsius = degreesCelsius;
            DegreesFahrenheit = degreesFahrenheit;
        }

        public int DegreesCelsius { get; init; }
        public int DegreesFahrenheit { get; init; }

        public static Temperature CreateFromDegreesCelsius(int degreesCelsius)
        {
            decimal degreesFahrenheit = (decimal)degreesCelsius * 9 / 5 + 32;
            return new(degreesCelsius, degreesFahrenheit.RoundToWholeNumber());
        }

        public static Temperature CreateFromDegreesFahrenheit(int degreesFahrenheit)
        {
            decimal degreesCelsius = ((decimal)degreesFahrenheit - 32) * 5 / 9;
            return new(degreesCelsius.RoundToWholeNumber(), degreesFahrenheit);
        }
    }
}
