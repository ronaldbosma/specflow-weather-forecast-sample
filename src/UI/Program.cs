using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using WeatherForecastSample.UI;
using WeatherForecastSample.UI.Apis;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddRefitClient<IWeatherForecastApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7288"))
                .SetHandlerLifetime(TimeSpan.FromMinutes(2));



await builder.Build().RunAsync();
