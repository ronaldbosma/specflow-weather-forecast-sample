using Microsoft.AspNetCore.Components;
using WeatherForecastSample.UI.Authentication;

namespace WeatherForecastSample.UI.Pages
{
    public class LogoutBase : ComponentBase
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await AuthenticationService.LogoutAsync();
            NavigationManager.NavigateTo("/login");
        }
    }
}
