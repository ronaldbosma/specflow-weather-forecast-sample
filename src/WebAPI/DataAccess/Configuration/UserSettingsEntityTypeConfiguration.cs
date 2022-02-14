using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess.Configuration
{
    internal class UserSettingsEntityTypeConfiguration : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder.HasKey(us => us.UserId);
            builder.Property(us => us.UserId).HasMaxLength(450).IsUnicode();

            builder.HasOne<Location>()
                   .WithMany()
                   .HasForeignKey(us => us.LocationId);

        }
    }
}
