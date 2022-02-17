# Demo Preparations

## Before giving demo

1. Fix scenarios so they work for 'today' on **all** branches.
1. Tip: snap Test Explorer in Visual Studio to left of screen and unpin. Use Ctrl+T, E to show Test Explorer.
1. Open 'demo/files' folder and the 'Specs' project folder side by side for copying files over.


## Branches

Follow the steps below to create 'demo' branches from `main`.

### Create baseline

1. Create `demo-1-start` branch from `main`
1. Remove all files from Specs project, except: `ImplicitUsings.cs` and `specflow.json`.
1. Remove `LocationId` from `WeatherForecast` and all its references.
    1. Remove seeding of weather forecasts for London and Madrid.
1. Remove the use of `DateOnly` in the Web API.
1. Remove implementation of method `Temperature.FromDegreesCelsius()`.
1. Remove method `Temperature.FromDegreesFahrenheit()`.
1. Remove reference to `SolidToken.SpecFlow.DependencyInjection` package.

### To DateOnly

#### DateOnly in interface

1. Create `demo-2-dateonly' branch from `demo-1-start`
1. Walk through the demo script until the step: _Switch to `demo-2-dateonly` branch_
1. Commit all changes
1. Replace `DateTime` with `DateOnly` in the service and repository interfaces. Fix all errors.
1. Commit (and push) all changes
1. Create `demo-3-dateonly-in-entity` branch from `demo-2-dateonly'

#### DateOnly in entity

1. Walk through the demo script until the step: _Switch to `demo-3-dateonly-in-entity` branch_
1. Commit all changes
1. Replace `DateTime` with `DateOnly` in the `WeatherForecast` entity. Fix all errors.
1. Add `global using WeatherForecastSample.Specs.Support;` to the implicit usings.
1. Commit (and push) all changes
1. Create `demo-4-share-dbcontext` branch from `demo-3-dateonly-in-entity`


### Context Injection

>TODO


