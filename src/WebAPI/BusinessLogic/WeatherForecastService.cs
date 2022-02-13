using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.BusinessLogic
{
    internal class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastService(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public WeatherForecast GetByDate(DateOnly date)
        {
            return _repository.GetByDate(date);
        }

        public IEnumerable<WeatherForecast> GetForComingWeek()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var sevenDaysFromToday = today.AddDays(7);

            return _repository.GetForDateRange(today, sevenDaysFromToday);
        }
    }
}
