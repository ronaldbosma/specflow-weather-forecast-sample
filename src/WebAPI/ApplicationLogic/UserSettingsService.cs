using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    internal class UserSettingsService : IUserSettingsService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserSettingsRepository _userSettingsRepository;

        public UserSettingsService(ICurrentUser currentUser, IUserSettingsRepository userSettingsRepository)
        {
            _currentUser = currentUser;
            _userSettingsRepository = userSettingsRepository;
        }

        public UserSettings GetUserSettingsForCurrentUser()
        {
            var username = _currentUser.GetUsername();
            return _userSettingsRepository.GetUserSettingsByUsername(username);
        }
    }
}
