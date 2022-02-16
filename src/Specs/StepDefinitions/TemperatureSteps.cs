using System;
using TechTalk.SpecFlow;
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

        [Then(@"the temperature is (.*) °F")]
        public void ThenTheTemperatureIsNumberOfDegreesFahrenheit(int expectedDegreesFahrenheit)
        {
            _actualTemperature.Should().NotBeNull();
            _actualTemperature!.DegreesFahrenheit.Should().Be(expectedDegreesFahrenheit);
        }
    }
}