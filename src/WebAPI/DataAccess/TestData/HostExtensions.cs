using Microsoft.AspNetCore.Identity;
using WeatherForecastSample.WebAPI.ApplicationLogic;

namespace WeatherForecastSample.WebAPI.DataAccess.TestData
{
    internal static class HostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<WeatherForecastDbContext>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var systemDate = services.GetRequiredService<ISystemDate>();

                // Always recreate database so we don't need migrations
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Seed test data
                new IdentityUserSeeder(context, userManager).SeedData();
                new LocationSeeder(context).SeedData();
                new UserSettingsSeeder(context, userManager).SeedData();
                new WeatherForecastSeeder(context, systemDate).SeedData();
            }

            return host;
        }
    }
}
