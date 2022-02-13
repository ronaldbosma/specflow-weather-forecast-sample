Feature: Convert Temperature

In order to reach a worldwide user base
As an app developer
I want to support both Celsius and Fahrenheit as the unit of temperature

The formula to convert Celsius to Fahrenheit is:
	°F = (°C * 9/5) + 32

The formula to convert Fahrenheit to Celsius is:
	°C = (°F - 32) * 5/9

37 °C is equivalent to 98.6 °F, but we only use whole numbers for the temperature.
We round to the nearest number, and when a number is halfway between two others,
it's rounded toward the nearest number that's away from zero.


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


Scenario Outline: Convert Fahrenheit to Celsius

	When the temperature is <fahrenheit> °F
	Then the temperature is <celsius> °C

	Examples:
		| case             | fahrenheit | celsius |
		| Absolute Zero    | -459       | -273    |
		| Parity           | -40        | -40     |
		| Freezing point   | 32         | 0       |
		| Body Temperature | 99         | 37      |
		| Boiling point    | 212        | 100     |