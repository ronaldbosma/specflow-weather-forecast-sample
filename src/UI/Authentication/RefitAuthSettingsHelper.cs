using Blazored.SessionStorage;
using Refit;

namespace WeatherForecastSample.UI.Authentication
{
    /// <summary>
    /// Helper class to configure auth header retrieval for Refit.
    /// </summary>
    internal static class RefitAuthSettingsHelper
    {
        public static RefitSettings CreateRefitSettings(IServiceProvider serviceProvider)
        {
            return new RefitSettings
            {
                AuthorizationHeaderValueGetter = async () =>
                {
                    // We create a scope because ISessionStorageService is registered as a scoped service.
                    using var scope = serviceProvider.CreateAsyncScope();

                    var sessionStorage = scope.ServiceProvider.GetRequiredService<ISessionStorageService>();
                    return await sessionStorage.GetItemAsync<string>(Constants.AuthenticationTokenStoreKey);
                }
            };
        }
    }
}
