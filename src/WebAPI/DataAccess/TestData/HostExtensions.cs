﻿using Microsoft.AspNetCore.Identity;

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

                // Ensure database exists
                context.Database.EnsureCreated();

                // Seed test data
                new IdentityUserSeeder(context, userManager).SeedData();
                new WeatherForecastSeeder(context).SeedData();
            }

            return host;
        }
    }
}