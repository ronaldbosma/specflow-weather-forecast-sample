using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using WeatherForecastSample.UI;
using WeatherForecastSample.UI.Apis;
using WeatherForecastSample.UI.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddRefitClient<IAccountApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288/api"))
                .SetHandlerLifetime(TimeSpan.FromMinutes(2));

builder.Services.AddTransient<AuthenticationHeaderHandler>();
builder.Services.AddRefitClient<IWeatherForecastApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288/api"))
                .SetHandlerLifetime(TimeSpan.FromMinutes(2))
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();

builder.Services.AddRefitClient<IUserSettingsApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288/api"))
                .SetHandlerLifetime(TimeSpan.FromMinutes(2))
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();

builder.Services.AddRefitClient<ILocationApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288/api"))
                .SetHandlerLifetime(TimeSpan.FromMinutes(2))
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

await builder.Build().RunAsync();
