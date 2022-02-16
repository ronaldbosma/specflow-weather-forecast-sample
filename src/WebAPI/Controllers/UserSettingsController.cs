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
        public UserSettings GetUserSettings()
        {
            var userSettings = _userSettingsService.GetUserSettingsForCurrentUser();
            return userSettings.MapToModel();
        }

        [HttpPut("/api/usersettings")]
        public void UpdateUserSettings([FromBody] UserSettings userSettings)
        {
            _userSettingsService.UpdateUserSettings(userSettings.MapToEntity());
        }
    }
}
