using Refit;
using WeatherForecastSample.Shared.Authentication;

namespace WeatherForecastSample.UI.Apis
{
    [Headers("Content-Type: application/json")]
    public interface IAccountApi
    {
        [Post("/accounts/login")]
        Task<IApiResponse<LoginResponse>> LoginAsync([Body]LoginRequest request);
    }
}
