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
        public WeatherForecast GetByDate(DateTime date)
        {
            return _context.WeatherForecasts.Single(wf => wf.Date == date);
        }

        /// <inheritdoc />
        public IEnumerable<WeatherForecast> GetForDateRange(DateTime fromDate, DateTime untilDate)
        {
            return _context.WeatherForecasts.Where(wf => wf.Date >= fromDate && wf.Date <= untilDate);
        }
    }
}
