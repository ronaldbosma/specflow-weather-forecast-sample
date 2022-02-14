using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WeatherForecastSample.WebAPI.ApplicationLogic;
using WeatherForecastSample.WebAPI.DataAccess;

namespace WeatherForecastSample.WebAPI
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherForecastDependencies(this IServiceCollection services)
        {
            return services
                .AddTransient<ILocationRepository, LocationRepository>()
                .AddTransient<IUserSettingsRepository, UserSettingsRepository>()
                .AddTransient<IUserSettingsService, UserSettingsService>()
                .AddTransient<IWeatherForecastRepository, WeatherForecastRepository>()
                .AddTransient<IWeatherForecastService, WeatherForecastService>();
        }

        public static IServiceCollection AddWeatherForecastDbContext(this IServiceCollection services)
        {
            return services.AddDbContext<WeatherForecastDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:WeatherForecastDatabase"));
        }

        public static IServiceCollection EnsureDatabaseExists(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetRequiredService<WeatherForecastDbContext>();
            context.Database.EnsureCreated();

            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfigurationSection jwtSettings)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<WeatherForecastDbContext>();

            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSettings["validIssuer"],
                        ValidAudience = jwtSettings["validAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
                    };
                });

            return services;
        }
    }
}
