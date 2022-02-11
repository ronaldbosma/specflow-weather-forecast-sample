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
    }
}
