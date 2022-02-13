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
            builder.Property(wf => wf.NumberOfMillimetresRain).HasPrecision(6, 1);

            AddTestData(builder);
        }

        private static void AddTestData(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasData(CreateWeatherForecast(1, DateTime.Today.AddDays(-1), WeatherType.Sunny, 12, 17, 0, 0, WindDirection.S, 0));
            builder.HasData(CreateWeatherForecast(2, DateTime.Today, WeatherType.Sunny, 9, 12, 0, 1, WindDirection.S, 1));
            builder.HasData(CreateWeatherForecast(3, DateTime.Today.AddDays(1), WeatherType.PartlyClouded, 5, 10, 0, 5, WindDirection.W, 1));
            builder.HasData(CreateWeatherForecast(4, DateTime.Today.AddDays(2), WeatherType.Cloudy, 3, 9, 0.2m, 20, WindDirection.E, 1));
            builder.HasData(CreateWeatherForecast(5, DateTime.Today.AddDays(3), WeatherType.Rainy, 2, 9, 12, 76, WindDirection.NW, 3));
            builder.HasData(CreateWeatherForecast(6, DateTime.Today.AddDays(4), WeatherType.Stormy, -1, 2, 32, 90, WindDirection.W, 6));
            builder.HasData(CreateWeatherForecast(7, DateTime.Today.AddDays(5), WeatherType.Snowy, -4, -1, 2, 22, WindDirection.N, 2));
            builder.HasData(CreateWeatherForecast(8, DateTime.Today.AddDays(6), WeatherType.Snowy, -5, 0, 2, 22, WindDirection.N, 2));
        }

        private static WeatherForecast CreateWeatherForecast(int id, DateTime date, WeatherType weatherType, int minimumTemperature, int maximumTemperature,
            decimal numberOfMillimetresRain, int percentageOfChanceOfRain, WindDirection windDirection, int windStrength)
        {
            return new()
            {
                Id = id,
                Date = DateOnly.FromDateTime(date),
                WeatherType = weatherType,
                MinimumTemperature = minimumTemperature,
                MaximumTemperature = maximumTemperature,
                NumberOfMillimetresRain = numberOfMillimetresRain,
                PercentageOfChanceOfRain = percentageOfChanceOfRain,
                WindDirection = windDirection,
                WindStrength = windStrength
            };
        }
    }
}
