using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Refit;
using System.Net;
using WeatherForecastSample.UI.Authentication;

namespace WeatherForecastSample.UI.Components
{
    /// <summary>
    /// This error boundary will logout an unauthorized user.
    /// </summary>
    public class HandleUnauthorizedErrorBoundary : ErrorBoundary
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = null!;

        [Inject]
        public ILogger<HandleUnauthorizedErrorBoundary> Logger { get; set; } = null!;

        protected override async Task OnErrorAsync(Exception exception)
        {
            if (exception is ApiException apiException && apiException.StatusCode == HttpStatusCode.Unauthorized)
            {
                await LogOutUnauthorizedUserAsync();
            }
            else
            {
                await base.OnErrorAsync(exception);
            }
        }

        private async Task LogOutUnauthorizedUserAsync()
        {
            Logger.LogInformation($"An HTTP Status Code {HttpStatusCode.Unauthorized} was returned. The user will be logged out.");
            await AuthenticationService.LogoutAsync();
            Recover(); //We need to Recover so the Login page will be shown after logging out
        }
    }
}
