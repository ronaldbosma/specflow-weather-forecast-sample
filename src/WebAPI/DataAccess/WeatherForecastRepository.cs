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

        public WeatherForecast GetByDate(DateOnly date)
        {
            return _context.WeatherForecasts.Single(wf => wf.Date == date);
        }

        public IEnumerable<WeatherForecast> GetForDateRange(DateOnly fromDate, DateOnly untilDate)
        {
            return _context.WeatherForecasts.Where(wf => wf.Date >= fromDate && wf.Date < untilDate);
        }
    }
}
