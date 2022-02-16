using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    internal class UserSettingsService : IUserSettingsService
    {
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly IUserSettingsRepository _userSettingsRepository;

        public UserSettingsService(IAuthenticatedUser authenticatedUser, IUserSettingsRepository userSettingsRepository)
        {
            _authenticatedUser = authenticatedUser;
            _userSettingsRepository = userSettingsRepository;
        }

        public UserSettings GetUserSettingsForCurrentUser()
        {
            var username = _authenticatedUser.GetUsername();
            return _userSettingsRepository.GetUserSettingsByUsername(username);
        }
    }
}
