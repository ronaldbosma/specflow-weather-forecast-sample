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
                // Perform the actual login (validating the username & password, and generating a token)
                var response = await _accountApi.LoginAsync(request);

                // Store the token of the authenticated user in session storage so it can be used in successive calls to the backend
                await _sessionStorage.SetItemAsync(Constants.AuthenticationTokenStoreKey, response.Token);

                // Notify Blazor that the user is logged in
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
            // Remove the stored token from the session storage
            if (await _sessionStorage.ContainKeyAsync(Constants.AuthenticationTokenStoreKey).ConfigureAwait(false))
            {
                await _sessionStorage.RemoveItemAsync(Constants.AuthenticationTokenStoreKey).ConfigureAwait(false);
            }

            // Notify Blazor that user user has been logged out and go to the login page
            _authenticationStateProvider.NotifyUserLogout();
            _navigationManager.NavigateTo("/login");
        }
    }
}
