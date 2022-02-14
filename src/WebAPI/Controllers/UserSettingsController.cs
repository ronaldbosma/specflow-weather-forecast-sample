using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastSample.Shared.Models;
using WeatherForecastSample.WebAPI.ApplicationLogic;
using WeatherForecastSample.WebAPI.Controllers.Mappers;

namespace WeatherForecastSample.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class UserSettingsController
    {
        private readonly IUserSettingsService _userSettingsService;

        public UserSettingsController(IUserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;
        }

        [HttpGet("/api/usersettings")]
        public async Task<UserSettings> GetUserSettingsAsync()
        {
            var userSettings = await _userSettingsService.GetUserSettingsForCurrentUserAsync();
            return userSettings.MapToModel();
        }
    }
}
