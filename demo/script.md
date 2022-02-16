# SpecFlow Demo Script

## Demo App

> TIP: after stopping the Web API en UI, I still got message from Visual Studio that I needed to restart the application for changes to take effect. So either stop & start Visual Studio after the demo, or create an extra clone of the repo so you can open the solution in a separate Visual Studio instance to start the app.

1. Show the app.
1. Stop the Web API and UI.

## Basics

1. Switch to the `demo-1-start` branch.

1. Show how to install SpecFlow extension
    1. Menu `Extensions > Manage Extensions'.
    1. Choose `Installed`.
    1. Search for `SpecFlow`.

1. Create new feature file `Convert Temperature.feature` and add the following content.
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

1. Build the solution and run the scenario. Show error message.

1. Generate step definition files
    1. Explain
        1. The `[Binding]` attribute.
        1. Class can be `internal`.
        1. The `[When]` and `[Then]` attributes.
        1. Use of regular expressions.
    1. Rename parameters.
    1. Rename method.
    1. Show 'Go to definition'.

1. Implement scenario

    ```csharp
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
    ```

1. **Multiple** attributes possible. E.g. the `When` can also have a `Given` attribute.

1. Execute scenario. It **fails** because the method is not yet implemented.
    1. Show output in Test Explorer window.

1. Implement `Temperature.FromDegreesCelsius()`
    ```csharp
    var degreesFahrenheit = degreesCelsius * 9 / 5 + 32;
    return new(degreesCelsius, degreesFahrenheit);
    ```

1. Add two more scenarios

    ```gherkin
    Scenario: Convert Absolute Zero

        When the temperature is -273 °C
        Then the temperature is -459 °F


    Scenario: Convert Boiling point

        When the temperature is 100 °C
        Then the temperature is 212 °F
    ```

1. Replace scenarios with scenario outline

    ```gherkin
    Scenario Outline: Convert Celsius to Fahrenheit

        When the temperature is <celsius> °C
        Then the temperature is <fahrenheit> °F

        Examples:
            | case             | celsius | fahrenheit |
            | Absolute Zero    | -273    | -459       |
            | Parity           | -40     | -40        |
            | Freezing point   | 0       | 32         |
            | Body Temperature | 37      | 99         |
            | Boiling point    | 100     | 212        |
    ```

1. Run scenario outline.
    1. See test names.
    1. Body Temperature case will fail.

1. Add comment about rounding

    ```gherkin
    37 °C is equivalent to 98.6 °F, but we only use whole numbers for the temperature.
    We round to the nearest number, and when a number is halfway between two others,
    it's rounded toward the nearest number that's away from zero.
    ```

1. Fix the implementation of `Temperature.FromDegreesCelsius`
    ```csharp
    public static Temperature FromDegreesCelsius(int degreesCelsius)
    {
        var degreesFahrenheit = (decimal)degreesCelsius * 9 / 5 + 32;
        return new(degreesCelsius, degreesFahrenheit.RoundToWholeNumber());
    }
    ```

1. Show **debugging** a scenario

## Assist Helpers

1. Uncomment feature `Retrieve weather forecast for a day`

1. Generate steps in `WeatherForecastSteps`.

1. Show implementation of `WeatherForecastService.GetByDate`.

1. Add private fields and constructor.

    ```csharp
    private readonly WeatherForecastService _weatherForecastService;
    private readonly WeatherForecastDbContext _dbContext;

    public WeatherForecastSteps()
    {
        var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>()
            .UseInMemoryDatabase("WeatherForecastSample.WeatherForecast");
        _dbContext = new WeatherForecastDbContext(optionsBuilder.Options);

        _weatherForecastService = new WeatherForecastService(
            new WeatherForecastRepository(_dbContext));
    }
    ```

1. Implement `Given`
    ```csharp
    [Given(@"the following weather forecasts")]
    public void GivenTheFollowingWeatherForecasts(Table table)
    {
        foreach (var row in table.Rows)
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse(row["Date"]),
                WeatherType = (WeatherType)Enum.Parse(typeof(WeatherType), row["Weather Type"]),
                MinimumTemperature = int.Parse(row["Minimum Temperature"]),
                MaximumTemperature = int.Parse(row["Maximum Temperature"])
            };
            _dbContext.WeatherForecasts.Add(weatherForecast);
        }
        _dbContext.SaveChanges();
    }
    ```

1. Implement `When`
    ```csharp
    [When(@"I retrieve the weather forecast for (.*)")]
    public void WhenIRetrieveTheWeatherForecastForFebruary(DateTime date)
    {
        _actualWeatherForecast = _weatherForecastService.GetByDate(date);
    }
    ```

1. Implement `Then`
    ```csharp
    [Then(@"the following weather forecast is returned")]
    public void ThenTheFollowingWeatherForecastIsReturned(Table table)
    {
        var expectedWeatherForecast = table.Rows.Single();
        _actualWeatherForecast.Should().NotBeNull();
        _actualWeatherForecast!.Date.Should().Be(DateTime.Parse(expectedWeatherForecast["Date"]));
        _actualWeatherForecast!.WeatherType.Should().Be((WeatherType)Enum.Parse(typeof(WeatherType), expectedWeatherForecast["Weather Type"]));
        _actualWeatherForecast!.MinimumTemperature.Should().Be(int.Parse(expectedWeatherForecast["Minimum Temperature"]));
        _actualWeatherForecast!.MaximumTemperature.Should().Be(int.Parse(expectedWeatherForecast["Maximum Temperature"]));
    }
    ```

1. Add assist namespace
    ```csharp
    using TechTalk.SpecFlow.Assist;
    ```

1. Replace `Given` implementation
    ```csharp
    var weatherForecasts = table.CreateSet<WeatherForecast>();
    _dbContext.WeatherForecasts.AddRange(weatherForecasts);
    _dbContext.SaveChanges();
    ```

1. Replace `Then` implementation
    ```csharp
    var expectedWeatherForecast = table.CreateInstance<WeatherForecast>();
    _actualWeatherForecast.Should().Be(expectedWeatherForecast);
    ```

1. Run test, it will **fail** ivm `Id`.

1. Replace `Then` implementation
    ```csharp
    table.CompareToInstance(_actualWeatherForecast);
    ```
1. Transpose table in `Then` step
    ```gherkin
    | Property            | Value            |
    | Date                | 14 February 2022 |
    | Weather Type        | Sunny            |
    | Minimum Temperature | 9                |
    | Maximum Temperature | 12               |
    ```

## Step Argument Transformations

1. Replace the date with `today` in `When` step.
    ```gherkin
    When I retrieve the weather forecast for today
    ```

1. Create `StepArgumentTransformations` class

1. Add `[Binding]` attribute.

1. Add step argument transformation for today.

    ```csharp
    [StepArgumentTransformation("(.*)")]
    public DateTime TodayToDateTime(string value)
    {
        return value == "today" ? DateTime.Today : DateTime.Parse(value);
    }
    ```

1. Simplify step argument transformation
    ```csharp
    [StepArgumentTransformation("today")]
    public DateTime TodayToDateTime()
    {
        return DateTime.Today;
    }
    ```

1. Add step argument transformation for `Table`
    ```csharp
    [StepArgumentTransformation]
    public IEnumerable<WeatherForecast> TableToWeatherForecasts(Table table)
    {
        return table.CreateSet<WeatherForecast>();
    }
    ```

1. Use `IEnumerable<WeatherForecast>` in step and remove use of `Table`.
    ```csharp
    [Given(@"the following weather forecasts")]
    public void GivenTheFollowingWeatherForecasts(IEnumerable<WeatherForecast> weatherForecasts)
    {
        _dbContext.WeatherForecasts.AddRange(weatherForecasts);
        _dbContext.SaveChanges();
    }
    ```
1. Switch to `demo-2-dateonly` branch

1. Add step argument transformation to convert `DateTime` to `DateOnly
    ```csharp
    [StepArgumentTransformation("(.*)")]
    public DateOnly DateTimeToDateOnly(DateTime dateTime)
    {
        return DateOnly.FromDateTime(dateTime);
    }
    ```

## Hooks

1. Add second weather forecast scenario for specific date
    ```gherkin
    Scenario: Retrieve weather forecast for specific date
        
        Given the following weather forecasts
            | Date             | Weather Type  | Minimum Temperature | Maximum Temperature |
            | 14 February 2022 | Sunny         | 12                  | 17                  |
            | 15 February 2022 | Sunny         | 9                   | 12                  |
            | 16 February 2022 | PartlyClouded | 5                   | 10                  |
        When I retrieve the weather forecast for 16 February 2022
        Then the following weather forecast is returned
            | Property            | Value            |
            | Date                | 16 February 2022 |
            | Weather Type        | PartlyClouded    |
            | Minimum Temperature | 5                |
            | Maximum Temperature | 10               |
    ```

1. Run **all** tests. One fails. Show error.

1. Run **only the failed** test. Test should succeed.

1. Add hook

    ```gherkin
    [BeforeScenario]
    public void CleanDatabase()
    {
        _dbContext.WeatherForecasts.RemoveRange(_dbContext.WeatherForecasts);
        _dbContext.SaveChanges();
    }
    ```

## Value Retrievers & Comparers

1. Switch to `demo-3-dateonly-in-ef` branch

1. Run scenario and show that second step fails.

1. Add Value Retriever
    ```csharp
    internal class DateOnlyValueRetriever : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType == typeof(DateOnly);
        }

        public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return DateOnly.Parse(keyValuePair.Value);
        }
    }
    ```

1. Register Value Retriever in new `AssistHelperHooks` file.
    ```csharp
    [Binding]
    internal class AssistHelperHooks
    {
        [BeforeTestRun]
        public static void RegisterAssistHelpersBeforeTestRun()
        {
            Service.Instance.ValueRetrievers.Register(new DateOnlyValueRetriever());
        }
    }
    ```

1. Execute scenario and show that `When` step succeeds, but `Then` step fails.

1. Add Value Comparer
    ```csharp
    internal class DateOnlyValueComparer : IValueComparer
    {
        public bool CanCompare(object actualValue)
        {
            return actualValue is DateOnly;
        }

        public bool Compare(string expectedValue, object actualValue)
        {
            var expectedDate = DateOnly.Parse(expectedValue);
            var actualDate = (DateOnly)actualValue;

            return expectedDate == actualDate;
        }
    }
    ```

1. Add Value Comparer registration to `AssistHelperHooks.RegisterAssistHelpersBeforeTestRun()`
    ```csharp

                Service.Instance.ValueComparers.Register(new DateOnlyValueComparer());
    ```