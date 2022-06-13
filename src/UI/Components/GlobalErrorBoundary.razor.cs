using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WeatherForecastSample.UI.Authentication;

namespace WeatherForecastSample.UI.Components
{
    /// <summary>
    /// Error boundary for global error handling.
    /// </summary>
    public class GlobalErrorBoundaryBase : ErrorBoundary
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = null!;

        public List<Exception> ReceivedExceptions { get; set; } = new();

        public bool IsApiConnectionError { get; set; }

        protected override async Task OnErrorAsync(Exception exception)
        {
            // Unfortunately we don't get a clear status code when the API can't be reached or the auth token is expired.
            // For demo purposes we just show a custom error message when connecting to the API fails.
            IsApiConnectionError = exception is HttpRequestException httpEx &&
                                   httpEx.StatusCode == null &&
                                   httpEx.Message == "TypeError: Failed to fetch";

            ReceivedExceptions.Add(exception);

            await base.OnErrorAsync(exception);
        }
        
        public async Task GoToLoginPageAsync()
        {
            ReceivedExceptions.Clear();
            await AuthenticationService.LogoutAsync();
            Recover(); //We need to Recover so the Login page will be shown after logging out
        }
    }
}
