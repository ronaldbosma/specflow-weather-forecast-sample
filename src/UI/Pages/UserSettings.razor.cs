using Microsoft.AspNetCore.Components;
using WeatherForecastSample.Shared.Models;
using WeatherForecastSample.UI.Apis;

namespace WeatherForecastSample.UI.Pages
{
    public class UserSettingsBase : ComponentBase
    {
        [Inject]
        public IUserSettingsApi UserSettingsApi { get; set; } = null!;

        [Inject]
        public ILocationApi LocationApi { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public WeatherForecastSample.Shared.Models.UserSettings? UserSettings { get; set; }

        public IEnumerable<Location> Locations { get; set; } = new List<Location>();

        protected override async Task OnInitializedAsync()
        {
            UserSettings = await UserSettingsApi.GetUserSettingsAsync();
            Locations = (await LocationApi.GetLocationsAsync()).OrderBy(l => l.Name);
        }

        public async Task ExecuteSaveUserSettingsAsync()
        {
            if (UserSettings != null)
            {
                await UserSettingsApi.UpdateUserSettingsAsync(UserSettings);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
