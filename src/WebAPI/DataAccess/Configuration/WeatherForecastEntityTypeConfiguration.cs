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
            builder.Property(wf => wf.Date).HasConversion<DateOnlyConverter, DateOnlyComparer>();

            AddTestData(builder);
        }

        private static void AddTestData(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasData(CreateWeatherForecast(1, DateTime.Today.AddDays(-1), WeatherType.Sunny, 12, 17));
            builder.HasData(CreateWeatherForecast(2, DateTime.Today, WeatherType.Sunny, 9, 12));
            builder.HasData(CreateWeatherForecast(3, DateTime.Today.AddDays(1), WeatherType.PartlyClouded, 5, 10));
            builder.HasData(CreateWeatherForecast(4, DateTime.Today.AddDays(2), WeatherType.Cloudy, 3, 9));
            builder.HasData(CreateWeatherForecast(5, DateTime.Today.AddDays(3), WeatherType.Rainy, 2, 9));
            builder.HasData(CreateWeatherForecast(6, DateTime.Today.AddDays(4), WeatherType.Stormy, -1, 2));
            builder.HasData(CreateWeatherForecast(7, DateTime.Today.AddDays(5), WeatherType.Snowy, -4, -1));
            builder.HasData(CreateWeatherForecast(8, DateTime.Today.AddDays(6), WeatherType.Snowy, -5, 0));
        }

        private static WeatherForecast CreateWeatherForecast(int id, DateTime date, WeatherType weatherType, int minimumTemperature, int maximumTemperature)
        {
            return new()
            {
                Id = id,
                Date = DateOnly.FromDateTime(date),
                WeatherType = weatherType,
                MinimumTemperature = minimumTemperature,
                MaximumTemperature = maximumTemperature
            };
        }
    }
}
