# Demo Preparations


## Create baseline

1. Create `demo-1-start` branch from `main`
1. Remove all files from Specs project, except: `ImplicitUsings.cs` and `specflow.json`.
1. Remove `LocationId` from `WeatherForecast` and all its references.
    1. Remove seeding of weather forecasts for London and Madrid.
1. Remove the use of `DateOnly` in the Web API.
1. Remove implementation of method `Temperature.FromDegreesCelsius()`.
1. Remove method `Temperature.FromDegreesFahrenheit()`.

TODO: Remove reference to `SolidToken.SpecFlow.DependencyInjection` package on`demo-1-start` branch.
TODO?: `global using WeatherForecastSample.Shared;`


## To DateOnly

### DateOnly in interface

1. Create `demo-2-dateonly' branch from `demo-1-start`
1. Walk through the demo script until the step: _Switch to `demo-2-dateonly` branch_
1. Commit all changes
1. Replace `DateTime` with `DateOnly` in the service and repository interfaces. Fix all errors.
1. Commit (and push) all changes
1. Create `demo-3-dateonly-in-entity` branch from `demo-2-dateonly'

### DateOnly in entity

1. Walk through the demo script until the step: _Switch to `demo-3-dateonly-in-entity` branch_
1. Commit all changes
1. Replace `DateTime` with `DateOnly` in the `WeatherForecast` entity. Fix all errors.
TODO: 1. Add `global using WeatherForecastSample.Specs.Support;` to the implicit usings.
1. Commit (and push) all changes
1. Create `demo-4-share-dbcontext` branch from `demo-3-dateonly-in-entity`




## Before giving demo

1. Tip: snap Test Explorer in Visual Studio to left of screen and unpin. Use Ctrl+T, E to show Test Explorer.
1. Open 'demo/files' folder and the 'Specs' project folder side by side for copying files over.


1. Fix scenarios so they work for 'today' on **all** branches.
1. Remove feature file
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




