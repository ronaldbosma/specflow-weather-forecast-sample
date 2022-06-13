using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
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
        private readonly ISessionStorageService _sessionStorage;
        private readonly NavigationManager _navigationManager;

        public AuthenticationService(
            IAccountApi accountApi,
            AuthenticationStateProvider authenticationStateProvider,
            ISessionStorageService sessionStorage,
            NavigationManager navigationManager)
        {
            _accountApi = accountApi;
            _authenticationStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
            _sessionStorage = sessionStorage;
            _navigationManager = navigationManager;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            try
            {
                var response = await _accountApi.LoginAsync(request);

                await _sessionStorage.SetItemAsync(Constants.AuthenticationTokenStoreKey, response.Token);
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
            if (await _sessionStorage.ContainKeyAsync(Constants.AuthenticationTokenStoreKey).ConfigureAwait(false))
            {
                await _sessionStorage.RemoveItemAsync(Constants.AuthenticationTokenStoreKey).ConfigureAwait(false);
            }
            _authenticationStateProvider.NotifyUserLogout();
            _navigationManager.NavigateTo("/login");
        }
    }
}
