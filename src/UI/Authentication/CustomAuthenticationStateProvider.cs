using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WeatherForecastSample.UI.Authentication
{
    /// <summary>
    /// Custom <see cref="AuthenticationStateProvider"/> that is used to provide the authentication state of the current user.
    /// </summary>
    /// <remarks>
    /// This provider relies on the existens of a token the current user stored in session storage.
    /// </remarks>
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;

        private readonly static AuthenticationState Anonymous = new(new ClaimsPrincipal(new ClaimsIdentity()));

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _sessionStorage.GetItemAsync<string>(Constants.AuthenticationTokenStoreKey);

            // NOTE: the current user is not logged in if no token was found in session storage
            if (string.IsNullOrWhiteSpace(token))
            {
                return Anonymous;
            }

            // Return the authentication state based on the users token that was stored in session storage
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), Constants.AuthenticationType)));
        }

        public void NotifyUserAuthentication(string username)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, Constants.AuthenticationType));
            var authenticationState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authenticationState);
        }

        public void NotifyUserLogout()
        {
            var authenticationState = Task.FromResult(Anonymous);
            NotifyAuthenticationStateChanged(authenticationState);
        }
    }
}
