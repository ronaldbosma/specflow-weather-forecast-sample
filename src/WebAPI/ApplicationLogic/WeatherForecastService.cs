using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    internal class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;
        private readonly IUserSettingsService _userSettingsService;

        public WeatherForecastService(IWeatherForecastRepository repository, IUserSettingsService userSettings)
        {
            _repository = repository;
            _userSettingsService = userSettings;
        }

        public WeatherForecast GetByDate(DateOnly date)
        {
            var locationId = _userSettingsService.GetUserSettingsForCurrentUserAsync().Result.LocationId;
            return _repository.GetByDate(locationId, date);
        }

        public IEnumerable<WeatherForecast> GetForComingWeek()
        {
            var locationId = _userSettingsService.GetUserSettingsForCurrentUserAsync().Result.LocationId;
            var today = DateOnly.FromDateTime(DateTime.Today);
            var endOfComingWeek = today.AddDays(6);

            return _repository.GetForDateRange(locationId, today, endOfComingWeek);
        }
    }
}
