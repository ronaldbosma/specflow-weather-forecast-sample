Feature: Retrieve weather forecast for coming week

In order to have a good overview of the weather forecast for the coming days
As a user
I want to be able to retrieve the weather forecasts for the coming week

Note: the default unit of temperature is °C.


Scenario: Retrieve weather forecast for the coming week
    
    Given the following weather forecasts
        | Date             | Weather Type | Minimum Temperature | Maximum Temperature |
        | 10 February 2022 | Sunny        | 12                  | 17                  |
        | 11 February 2022 | Sunny        | 9                   | 12                  |
        | 12 February 2022 | Cloudy       | 5                   | 10                  |
        | 13 February 2022 | Rainy        | 3                   | 9                   |
        | 14 February 2022 | Rainy        | 2                   | 9                   |
        | 15 February 2022 | Stormy       | -1                  | 2                   |
        | 16 February 2022 | Snowy        | -4                  | -1                  |
        | 17 February 2022 | Snowy        | -5                  | 0                   |
        | 18 February 2022 | Cloudy       | 0                   | 3                   |
    When I retrieve the weather forecasts for the coming week
    Then the following weather forecasts are returned
        | Date             | Weather Type | Minimum Temperature | Maximum Temperature |
        | 11 February 2022 | Sunny        | 9                   | 12                  |
        | 12 February 2022 | Cloudy       | 5                   | 10                  |
        | 13 February 2022 | Rainy        | 3                   | 9                   |
        | 14 February 2022 | Rainy        | 2                   | 9                   |
        | 15 February 2022 | Stormy       | -1                  | 2                   |
        | 16 February 2022 | Snowy        | -4                  | -1                  |
        | 17 February 2022 | Snowy        | -5                  | 0                   |
