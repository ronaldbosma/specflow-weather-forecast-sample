using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherForecastSample.WebAPI.DataAccess.Configuration;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal class WeatherForecastDbContext : IdentityDbContext<IdentityUser>
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeatherForecastEntityTypeConfiguration).Assembly);
        }

        public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

        public DbSet<Location> Locations => Set<Location>();

        public DbSet<UserSettings> UserSettings => Set<UserSettings>();
    }
}
