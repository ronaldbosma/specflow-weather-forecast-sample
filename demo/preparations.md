# Demo Preparations

1. Fix scenarios so they work for 'today' on **all** branches.
1. Comment scenarios in feature files.
1. Start scenario for converting temperature.

    ```gherkin
    Feature: Convert Temperature

    In order to reach a worldwide user base
    As an app developer
    I want to support both Celsius and Fahrenheit as the unit of temperature

    The formula to convert Celsius to Fahrenheit is:
        °F = (°C * 9/5) + 32


    Scenario: Convert Freezing point

        When the temperature is 0 °C
        Then the temperature is 32 °F
    ```
1. Remove `Convert Temperature.feature`.
1. Remove classes under `Hooks`, `StepDefinitions` and `Support`.
1. Remove implementation of method `Temperature.FromDegreesCelsius()`.
1. Remove method `Temperature.FromDegreesFahrenheit()`.
1. Change parameter type from `DateOnly` to `DateTime` in `WeatherForecastService.GetByDate`.
    1. Also change the interface and controller.
1. Use `DateTime` in `WeatherForecast`
1. Add `using FluentAssertions;` as global namespace.
1. In `demo.md`, fix the expected date to the current date.
1. For scenario `Retrieve weather forecast for specific date` fix the expected date.


Maybe
1. Create branch for switch to `DateOnly`
