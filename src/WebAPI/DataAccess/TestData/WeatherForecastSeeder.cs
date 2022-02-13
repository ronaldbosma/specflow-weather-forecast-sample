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
            AddWeatherForecast(DateTime.Today.AddDays(-1), WeatherType.Sunny, 12, 17, 0, 0, WindDirection.S, 0);
            AddWeatherForecast(DateTime.Today, WeatherType.Sunny, 9, 12, 0, 1, WindDirection.S, 1);
            AddWeatherForecast(DateTime.Today.AddDays(1), WeatherType.PartlyClouded, 5, 10, 0, 5, WindDirection.W, 1);
            AddWeatherForecast(DateTime.Today.AddDays(2), WeatherType.Cloudy, 3, 9, 0.2m, 20, WindDirection.E, 1);
            AddWeatherForecast(DateTime.Today.AddDays(3), WeatherType.Rainy, 2, 9, 12, 76, WindDirection.NW, 3);
            AddWeatherForecast(DateTime.Today.AddDays(4), WeatherType.Stormy, -1, 2, 32, 90, WindDirection.W, 6);
            AddWeatherForecast(DateTime.Today.AddDays(5), WeatherType.Snowy, -4, -1, 2, 22, WindDirection.N, 2);
            AddWeatherForecast(DateTime.Today.AddDays(6), WeatherType.Snowy, -5, 0, 2, 22, WindDirection.N, 2);

            _context.SaveChanges();
        }

        private void AddWeatherForecast(DateTime dateTime, WeatherType weatherType, int minimumTemperature, int maximumTemperature,
            decimal numberOfMillimetresRain, int percentageOfChanceOfRain, WindDirection windDirection, int windStrength)
        {
            var date = DateOnly.FromDateTime(dateTime);
            var weatherForecastDoesNotExists = !_context.WeatherForecasts.Any(wf => wf.Date == date);

            if (weatherForecastDoesNotExists)
            {
                _context.WeatherForecasts.Add(new WeatherForecast
                {
                    Date = date,
                    WeatherType = weatherType,
                    MinimumTemperature = minimumTemperature,
                    MaximumTemperature = maximumTemperature,
                    NumberOfMillimetresRain = numberOfMillimetresRain,
                    PercentageOfChanceOfRain = percentageOfChanceOfRain,
                    WindDirection = windDirection,
                    WindStrength = windStrength
                });
            }
        }
    }
}