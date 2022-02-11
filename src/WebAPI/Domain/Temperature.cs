namespace WeatherForecastSample.WebAPI.Domain
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
            decimal degreesFahrenheit = ((decimal)degreesCelsius * 9 / 5) + 32;
            int degreesFahrenheitRoundedOf = (int)Math.Round(degreesFahrenheit, 0, MidpointRounding.AwayFromZero);

            return new(degreesCelsius, degreesFahrenheitRoundedOf);
        }
    }
}
