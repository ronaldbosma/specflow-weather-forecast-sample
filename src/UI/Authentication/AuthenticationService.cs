using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Refit;
using System.Net;
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
            try
            {
                var response = await _accountApi.LoginAsync(request);

                //TODO: use session storage instead of local storage
                await _localStorage.SetItemAsync(Constants.AuthenticationTokenStoreKey, response.Token);
                _authenticationStateProvider.NotifyUserAuthentication(request.Username);

                return new LoginResponse { IsAuthenticationSuccessful = true };
            }
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new LoginResponse { ErrorMessage = "Login failed. Enter a valid username and password." };
            }
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync(Constants.AuthenticationTokenStoreKey);
            _authenticationStateProvider.NotifyUserLogout();
        }
    }
}
