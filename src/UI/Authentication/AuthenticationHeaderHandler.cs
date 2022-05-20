using Blazored.SessionStorage;
using System.Net;
using System.Net.Http.Headers;

namespace WeatherForecastSample.UI.Authentication
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        private readonly ISessionStorageService _sessionStorage;
        private readonly ILogger<AuthenticationHeaderHandler> _logger;

        public AuthenticationHeaderHandler(ISessionStorageService sessionStorage,ILogger<AuthenticationHeaderHandler> logger) 
            : base()
        {
            _sessionStorage = sessionStorage;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _sessionStorage.GetItemAsync<string>(Constants.AuthenticationTokenStoreKey);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                return response;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == null && ex.Message == "TypeError: Failed to fetch")
            {
                _logger.LogError(ex, $"{ex.GetType()} was raised with message {ex.Message}, which most likely means the user is unauthorized due to an expired token");

                // We don't receive a response message with Unauthorized (401) when the token is expired.
                // Instead a HttpRequestException is thrown from javascript with the message 'TypeError: Failed to fetch'.
                // So we return an Unauthorized (401) response message.
                return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    RequestMessage = request
                };
            }
        }
    }
}