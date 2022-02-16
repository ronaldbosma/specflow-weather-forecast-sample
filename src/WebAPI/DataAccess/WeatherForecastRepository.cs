using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherForecastDbContext _context;

        public WeatherForecastRepository(WeatherForecastDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public WeatherForecast GetByDate(int locationId, DateOnly date)
        {
            return _context.WeatherForecasts.Single(wf => wf.LocationId == locationId && wf.Date == date);
        }

        /// <inheritdoc />
        public IEnumerable<WeatherForecast> GetForDateRange(int locationId, DateOnly fromDate, DateOnly untilDate)
        {
            return _context.WeatherForecasts.Where(wf => wf.LocationId == locationId && wf.Date >= fromDate && wf.Date <= untilDate);
        }
    }
}
