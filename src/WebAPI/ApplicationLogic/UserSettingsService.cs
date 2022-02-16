using Microsoft.AspNetCore.Identity;
using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    internal class UserSettingsService : IUserSettingsService
    {
        private readonly ICurrentUser _currentUser;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserSettingsRepository _userSettingsRepository;

        public UserSettingsService(ICurrentUser currentUser, UserManager<IdentityUser> userManager, IUserSettingsRepository userSettingsRepository)
        {
            _currentUser = currentUser;
            _userManager = userManager;
            _userSettingsRepository = userSettingsRepository;
        }

        public async Task<UserSettings> GetUserSettingsForCurrentUserAsync()
        {
            var userId = await GetUserIdAsync();
            return await _userSettingsRepository.GetUserSettingsAsync(userId);
        }

        private async Task<string> GetUserIdAsync()
        {
            var username = _currentUser.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new InvalidOperationException($"Unable to find user with name {username}");
            }

            return user.Id;
        }
    }
}
