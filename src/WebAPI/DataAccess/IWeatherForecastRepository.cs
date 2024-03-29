﻿using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal interface IWeatherForecastRepository
    {
        /// <summary>
        /// Gets a weather forecast for the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="locationId">The location of the weather forecast.</param>
        /// <param name="date">The date of the weather forecast.</param>
        /// <returns>the weather forecast.</returns>
        WeatherForecast GetByDate(int locationId, DateOnly date);

        /// <summary>
        /// Gets the forecasts for the specified date range.
        /// </summary>
        /// <param name="locationId">The location of the weather forecast.</param>
        /// <param name="fromDate">The start date of the date range.</param>
        /// <param name="untilDate">The end date of the date range. The weather forecast for the end date is included.</param>
        /// <returns>a collection of weather forecasts.</returns>
        IEnumerable<WeatherForecast> GetForDateRange(int locationId, DateOnly fromDate, DateOnly untilDate);
    }
}
