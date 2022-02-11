Feature: Retrieve weather forecast for a day

In order to view the weather forecast for a specific day
As a user
I want to be able to retrieve a weather forecast for a specified date

Note: the default unit of temperature is °C.


Scenario: Retrieve weather forecast
    
    Given the following weather forecasts
        | Date             | Weather Type | Minimum Temperature | Maximum Temperature |
        | 11 February 2021 | Sunny        | 9                   | 12                  |
        | 12 February 2021 | Cloudy       | 5                   | 10                  |
        | 13 February 2021 | Rainy        | 3                   | 9                   |
        | 14 February 2021 | Rainy        | 2                   | 9                   |
        | 15 February 2021 | Stormy       | -1                  | 2                   |
        | 16 February 2021 | Snowy        | -4                  | -1                  |
    When I retieve the weather forecast for '11 February 2021'
    Then the following weather forecast is returned
        | Date             | Weather Type | Minimum Temperature | Maximum Temperature |
        | 11 February 2021 | Sunny        | 9                   | 12                  |