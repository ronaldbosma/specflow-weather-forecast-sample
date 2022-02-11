using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Domain;

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
    }
}
