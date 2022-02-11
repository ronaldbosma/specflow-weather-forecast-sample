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

        public IEnumerable<WeatherForecast> GetForComingDays(int numberOfComingDays)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var lastDay = today.AddDays(numberOfComingDays);

            return _context.WeatherForecasts.Where(wf => wf.Date >= today && wf.Date < lastDay);
        }
    }
}
