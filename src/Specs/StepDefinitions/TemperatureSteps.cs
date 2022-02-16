using WeatherForecastSample.Shared;

namespace WeatherForecastSample.Specs.StepDefinitions
{
    [Binding]
    internal class TemperatureSteps
    {
        private Temperature? _actualTemperature;

        [When(@"the temperature is (.*) °C")]
        public void WhenTheTemperatureIsNumberOfDegreesCelsius(int degreesCelsius)
        {
            _actualTemperature = Temperature.FromDegreesCelsius(degreesCelsius);
        }

        [When(@"the temperature is (.*) °F")]
        public void WhenTheTemperatureIsF(int degreesFahrenheit)
        {
            _actualTemperature = Temperature.FromDegreesFahrenheit(degreesFahrenheit);
        }

        [Then(@"the temperature is (.*) °F")]
        public void ThenTheTemperatureIsNumberOfDegreesFahrenheit(int expectedDegreesFahrenheit)
        {
            _actualTemperature.Should().NotBeNull();
            _actualTemperature!.DegreesFahrenheit.Should().Be(expectedDegreesFahrenheit);
        }

        [Then(@"the temperature is (.*) °C")]
        public void ThenTheTemperatureIsC(int expectedDegreesCelsius)
        {
            _actualTemperature.Should().NotBeNull();
            _actualTemperature!.DegreesCelsius.Should().Be(expectedDegreesCelsius);
        }
    }
}