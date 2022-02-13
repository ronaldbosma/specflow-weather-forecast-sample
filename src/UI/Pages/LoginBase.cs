using Microsoft.AspNetCore.Components;
using WeatherForecastSample.Shared.Authentication;
using WeatherForecastSample.UI.Authentication;

namespace WeatherForecastSample.UI.Pages
{
    public class LoginBase : ComponentBase
    {
        public LoginRequest LoginRequest { get; init; } = new LoginRequest { Email = "john@example.org", Password = "P@ssw0rd" };

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public bool ShowAuthError { get; set; }

        public string? Error { get; set; }

        public async Task ExecuteLoginAsync()
        {
            ShowAuthError = false;

            var result = await AuthenticationService.LoginAsync(LoginRequest);
            if (!result.IsAuthenticationSuccessful)
            {
                Error = result.ErrorMessage;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
