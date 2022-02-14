using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using WeatherForecastSample.Shared.Authentication;
using WeatherForecastSample.UI.Apis;

namespace WeatherForecastSample.UI.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountApi _accountApi;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(IAccountApi accountApi, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _accountApi = accountApi;
            _authStateProvider = authStateProvider;
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
            ((CustomAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(request.Email);

            return new LoginResponse {  IsAuthenticationSuccessful = true };
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync(Constants.AuthenticationTokenStoreKey);
            ((CustomAuthenticationStateProvider)_authStateProvider).NotifyUserLogout();
        }
    }
}
