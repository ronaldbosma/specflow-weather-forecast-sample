using Microsoft.EntityFrameworkCore;
using WeatherForecastSample.WebAPI.DataAccess.Configuration;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeatherForecastEntityTypeConfiguration).Assembly);
        }

        public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
    }
}
