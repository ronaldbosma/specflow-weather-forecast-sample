using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal interface IWeatherForecastRepository
    {
        /// <summary>
        /// Gets a weather forecast for the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date of the weather forecast.</param>
        /// <returns>the weather forecast.</returns>
        WeatherForecast GetByDate(DateOnly date);

        /// <summary>
        /// Gets the forecasts for the specified date range.
        /// </summary>
        /// <param name="startDate">The start date of the date range.</param>
        /// <param name="endDate">The end date of the date range. The weather forecast for the end date is NOT included.</param>
        /// <returns>a collection of weather forecasts.</returns>
        IEnumerable<WeatherForecast> GetForDateRange(DateOnly startDate, DateOnly endDate);
    }
}
