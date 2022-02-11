﻿using Microsoft.EntityFrameworkCore;
using WeatherForecastSample.WebAPI.Domain;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
    }
}
