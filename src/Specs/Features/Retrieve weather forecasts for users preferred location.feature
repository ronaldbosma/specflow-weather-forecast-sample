Feature: Retrieve weather forecasts for users preferred location

In order for the retrieved weather forecasts to be useful
As a user
I want see weather forecasts for a specific location.


Scenario: Retrieve weather forecast by day for user location
    
    Given the authenticated user 'Jane'
        And the preferred location of 'Jane' is 'London'
        And the following weather forecasts
            | Date          | Location  | Weather Type  |
            | 16 March 2022 | Amsterdam | PartlyClouded |
            | 16 March 2022 | London    | Rainy         |
            | 16 March 2022 | Madrid    | Sunny         |
    When I retrieve the weather forecast for 16 March 2022
    Then the weather forecast for 'London' is returned