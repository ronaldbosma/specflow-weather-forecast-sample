Feature: Retrieve weather forecast for a day

In order to view the weather forecast for a specific day
As a user
I want to be able to retrieve a weather forecast for a specified date

Note: the default unit of temperature is °C.


Scenario: Retrieve weather forecast
    
    Given the following weather forecasts
        | Date             | Weather Type  | Minimum Temperature | Maximum Temperature |
        | 16 February 2022 | Sunny         | 12                  | 17                  |
        | 17 February 2022 | Sunny         | 9                   | 12                  |
        | 18 February 2022 | PartlyClouded | 5                   | 10                  |
    When I retrieve the weather forecast for today
    Then the following weather forecast is returned
        | Property            | Value            |
        | Date                | 17 February 2022 |
        | Weather Type        | Sunny            |
        | Minimum Temperature | 9                |
        | Maximum Temperature | 12               |


Scenario: Retrieve weather forecast specific date
    
    Given the following weather forecasts
        | Date             | Weather Type  | Minimum Temperature | Maximum Temperature |
        | 16 February 2022 | Sunny         | 12                  | 17                  |
        | 17 February 2022 | Sunny         | 9                   | 12                  |
        | 18 February 2022 | PartlyClouded | 5                   | 10                  |
    When I retrieve the weather forecast for 17 February 2022
    Then the following weather forecast is returned
        | Property            | Value            |
        | Date                | 17 February 2022 |
        | Weather Type        | Sunny            |
        | Minimum Temperature | 9                |
        | Maximum Temperature | 12               |