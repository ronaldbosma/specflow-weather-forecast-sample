using Blazored.SessionStorage;
using System.Net.Http.Headers;

namespace WeatherForecastSample.UI.Authentication
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        private readonly ISessionStorageService _sessionStorage;

        public AuthenticationHeaderHandler(ISessionStorageService sessionStorage) 
            : base()
        {
            _sessionStorage = sessionStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _sessionStorage.GetItemAsync<string>(Constants.AuthenticationTokenStoreKey);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}