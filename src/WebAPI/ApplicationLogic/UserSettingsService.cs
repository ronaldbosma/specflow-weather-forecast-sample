using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    internal class UserSettingsService : IUserSettingsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserSettingsRepository _userSettingsRepository;

        public UserSettingsService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager, IUserSettingsRepository userSettingsRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userSettingsRepository = userSettingsRepository;
        }

        public async Task<UserSettings> GetUserSettingsForCurrentUserAsync()
        {
            var userId = await GetCurrentUserIdAsync();
            return await _userSettingsRepository.GetUserSettingsAsync(userId);
        }

        private async Task<string> GetCurrentUserIdAsync()
        {
            var username = GetCurrentUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new InvalidOperationException($"Unable to find user with name {username}");
            }

            return user.Id;
        }

        private string GetCurrentUsername()
        {
            var nameClaim = _httpContextAccessor.HttpContext?.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name);
            if (string.IsNullOrWhiteSpace(nameClaim?.Value))
            {
                throw new InvalidOperationException("Username not found in claims.");
            }

            return nameClaim.Value;
        }
    }
}
