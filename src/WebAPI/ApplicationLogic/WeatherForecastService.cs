﻿using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    internal class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastService(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public WeatherForecast GetByDate(DateTime date)
        {
            return _repository.GetByDate(date);
        }

        public IEnumerable<WeatherForecast> GetForComingWeek()
        {
            var today = DateTime.Today;
            var endOfComingWeek = today.AddDays(6);

            return _repository.GetForDateRange(today, endOfComingWeek);
        }
    }
}
