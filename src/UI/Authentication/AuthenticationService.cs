using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using WeatherForecastSample.Shared.Authentication;
using WeatherForecastSample.UI.Apis;

namespace WeatherForecastSample.UI.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountApi _accountApi;
        private readonly CustomAuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(IAccountApi accountApi, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
        {
            _accountApi = accountApi;
            _authenticationStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = await _accountApi.LoginAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return new LoginResponse { ErrorMessage = response.Error?.ToString() };
            }
            if (response.Content == null)
            {
                return new LoginResponse { ErrorMessage = "No token received" };
            }

            await _localStorage.SetItemAsync(Constants.AuthenticationTokenStoreKey, response.Content.Token);
            _authenticationStateProvider.NotifyUserAuthentication(request.Email);

            return new LoginResponse {  IsAuthenticationSuccessful = true };
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync(Constants.AuthenticationTokenStoreKey);
            _authenticationStateProvider.NotifyUserLogout();
        }
    }
}
