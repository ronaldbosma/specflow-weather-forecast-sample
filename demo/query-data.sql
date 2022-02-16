USE [WeatherForecastSample.WeatherForecast]

SELECT u.UserName, us.TemperatureUnit, l.[Name] AS Location
FROM AspNetUsers u
	INNER JOIN UserSettings us ON u.Id = us.UserId
	INNER JOIN Locations l ON us.LocationId = l.Id
ORDER BY u.UserName

SELECT l.[Name] AS [Location], wf.*
FROM WeatherForecasts wf
	INNER JOIN Locations l ON wf.LocationId = l.Id
ORDER BY l.[Name], wf.[Date]