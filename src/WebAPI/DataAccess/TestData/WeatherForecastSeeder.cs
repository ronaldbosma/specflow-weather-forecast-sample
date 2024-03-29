﻿using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess.TestData
{
    internal class WeatherForecastSeeder
    {
        private readonly WeatherForecastDbContext _context;

        public WeatherForecastSeeder(WeatherForecastDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddWeatherForecastsForAmsterdam();
            AddWeatherForecastsForLondon();
            AddWeatherForecastsForMadrid();

            _context.SaveChanges();
        }

        private void AddWeatherForecastsForAmsterdam()
        {
            AddWeatherForecast("Amsterdam", DateTime.Today.AddDays(-1), WeatherType.Sunny, 12, 17, 0, 0, WindDirection.S, 0);
            AddWeatherForecast("Amsterdam", DateTime.Today, WeatherType.Sunny, 9, 12, 0, 1, WindDirection.S, 1);
            AddWeatherForecast("Amsterdam", DateTime.Today.AddDays(1), WeatherType.PartlyClouded, 5, 10, 0, 5, WindDirection.W, 1);
            AddWeatherForecast("Amsterdam", DateTime.Today.AddDays(2), WeatherType.Cloudy, 3, 9, 0.2m, 20, WindDirection.E, 1);
            AddWeatherForecast("Amsterdam", DateTime.Today.AddDays(3), WeatherType.Rainy, 2, 9, 12, 76, WindDirection.NW, 3);
            AddWeatherForecast("Amsterdam", DateTime.Today.AddDays(4), WeatherType.Stormy, -1, 2, 32, 90, WindDirection.W, 6);
            AddWeatherForecast("Amsterdam", DateTime.Today.AddDays(5), WeatherType.Snowy, -4, -1, 2, 22, WindDirection.N, 2);
            AddWeatherForecast("Amsterdam", DateTime.Today.AddDays(6), WeatherType.Snowy, -5, 0, 2, 22, WindDirection.N, 2);
        }

        private void AddWeatherForecastsForLondon()
        {
            AddWeatherForecast("London", DateTime.Today.AddDays(-1), WeatherType.PartlyClouded, 13, 15, 0, 5, WindDirection.W, 1);
            AddWeatherForecast("London", DateTime.Today, WeatherType.Rainy, 11, 12, 0.2m, 20, WindDirection.E, 1);
            AddWeatherForecast("London", DateTime.Today.AddDays(1), WeatherType.Rainy, 10, 13, 12, 76, WindDirection.NW, 3);
            AddWeatherForecast("London", DateTime.Today.AddDays(2), WeatherType.Stormy, 9, 9, 32, 90, WindDirection.W, 6);
            AddWeatherForecast("London", DateTime.Today.AddDays(3), WeatherType.Rainy, 10, 11, 2, 77, WindDirection.N, 2);
            AddWeatherForecast("London", DateTime.Today.AddDays(4), WeatherType.Rainy, 11, 12, 2, 77, WindDirection.N, 2);
            AddWeatherForecast("London", DateTime.Today.AddDays(5), WeatherType.Rainy, 11, 12, 5, 80, WindDirection.S, 0);
            AddWeatherForecast("London", DateTime.Today.AddDays(6), WeatherType.Cloudy, 11, 13, 0, 1, WindDirection.S, 1);
        }

        private void AddWeatherForecastsForMadrid()
        {
            AddWeatherForecast("Madrid", DateTime.Today.AddDays(-1), WeatherType.Sunny, 17, 28, 0, 0, WindDirection.S, 0);
            AddWeatherForecast("Madrid", DateTime.Today, WeatherType.Sunny, 18, 29, 0, 0, WindDirection.S, 0);
            AddWeatherForecast("Madrid", DateTime.Today.AddDays(1), WeatherType.Sunny, 19, 30, 0, 0, WindDirection.SE, 0);
            AddWeatherForecast("Madrid", DateTime.Today.AddDays(2), WeatherType.Sunny, 20, 31, 0, 0, WindDirection.SE, 0);
            AddWeatherForecast("Madrid", DateTime.Today.AddDays(3), WeatherType.Sunny, 19, 30, 0, 0, WindDirection.S, 0);
            AddWeatherForecast("Madrid", DateTime.Today.AddDays(4), WeatherType.Sunny, 18, 29, 0, 0, WindDirection.S, 0);
            AddWeatherForecast("Madrid", DateTime.Today.AddDays(5), WeatherType.PartlyClouded, 17, 28, 0, 0, WindDirection.SW, 1);
            AddWeatherForecast("Madrid", DateTime.Today.AddDays(6), WeatherType.PartlyClouded, 16, 27, 0, 0, WindDirection.SW, 1);
        }

        private void AddWeatherForecast(string locationName, DateTime dateTime, WeatherType weatherType, int minimumTemperature, int maximumTemperature,
            decimal numberOfMillimetresRain, int percentageOfChanceOfRain, WindDirection windDirection, int windStrength)
        {
            var date = DateOnly.FromDateTime(dateTime);
            var weatherForecastDoesNotExists = !_context.WeatherForecasts.Any(wf => wf.Date == date);

            if (weatherForecastDoesNotExists)
            {
                var location = _context.Locations.Single(l => l.Name == locationName);

                _context.WeatherForecasts.Add(new WeatherForecast
                {
                    Date = date,
                    WeatherType = weatherType,
                    MinimumTemperature = minimumTemperature,
                    MaximumTemperature = maximumTemperature,
                    NumberOfMillimetresRain = numberOfMillimetresRain,
                    PercentageOfChanceOfRain = percentageOfChanceOfRain,
                    WindDirection = windDirection,
                    WindStrength = windStrength,
                    LocationId = location.Id
                });
            }
        }
    }
}
