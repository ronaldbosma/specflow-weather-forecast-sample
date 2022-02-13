using WeatherForecastSample.Shared.Authentication;

namespace WeatherForecastSample.UI.Authentication
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);

        Task LogoutAsync();
    }
}
