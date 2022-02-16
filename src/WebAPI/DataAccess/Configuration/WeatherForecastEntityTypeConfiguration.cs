using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess.Configuration
{
    internal class WeatherForecastEntityTypeConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasKey(wf => wf.Id);
            builder.HasIndex(wf => wf.Date).IsUnique();
            builder.Property(wf => wf.NumberOfMillimetresRain).HasPrecision(6, 1);
        }
    }
}
