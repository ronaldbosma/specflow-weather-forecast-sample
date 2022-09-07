using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    internal class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;
        private readonly IUserSettingsService _userSettingsService;
        private readonly ISystemDate _systemDate;

        public WeatherForecastService(IWeatherForecastRepository repository, IUserSettingsService userSettings, ISystemDate systemDate)
        {
            _repository = repository;
            _userSettingsService = userSettings;
            _systemDate = systemDate;
        }

        public WeatherForecast GetByDate(DateOnly date)
        {
            var locationId = _userSettingsService.GetUserSettingsForCurrentUser().LocationId;
            return _repository.GetByDate(locationId, date);
        }

        public IEnumerable<WeatherForecast> GetForComingWeek()
        {
            var locationId = _userSettingsService.GetUserSettingsForCurrentUser().LocationId;
            var endOfComingWeek = _systemDate.Today.AddDays(6);

            return _repository.GetForDateRange(locationId, _systemDate.Today, endOfComingWeek);
        }
    }
}
