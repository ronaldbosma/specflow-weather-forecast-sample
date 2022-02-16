Feature: Retrieve weather forecast for coming week

In order to have a good overview of the weather forecast for the coming days
As a user
I want to be able to retrieve the weather forecasts for the coming week

Note: the default unit of temperature is °C.


Scenario: Retrieve weather forecast for the coming week
    
    Given the following weather forecasts
        | Date             | Weather Type  | Minimum Temperature | Maximum Temperature |
        | 15 February 2022 | Sunny         | 12                  | 17                  |
        | 16 February 2022 | Sunny         | 9                   | 12                  |
        | 17 February 2022 | PartlyClouded | 5                   | 10                  |
        | 18 February 2022 | Cloudy        | 3                   | 9                   |
        | 19 February 2022 | Rainy         | 2                   | 9                   |
        | 20 February 2022 | Stormy        | -1                  | 2                   |
        | 21 February 2022 | Snowy         | -4                  | -1                  |
        | 22 February 2022 | Snowy         | -5                  | 0                   |
        | 23 February 2022 | Cloudy        | 0                   | 3                   |
    When I retrieve the weather forecasts for the coming week
    Then the following weather forecasts are returned
        | Date             | Weather Type  | Minimum Temperature | Maximum Temperature |
        | 16 February 2022 | Sunny         | 9                   | 12                  |
        | 17 February 2022 | PartlyClouded | 5                   | 10                  |
        | 18 February 2022 | Cloudy        | 3                   | 9                   |
        | 19 February 2022 | Rainy         | 2                   | 9                   |
        | 20 February 2022 | Stormy        | -1                  | 2                   |
        | 21 February 2022 | Snowy         | -4                  | -1                  |
        | 22 February 2022 | Snowy         | -5                  | 0                   |
