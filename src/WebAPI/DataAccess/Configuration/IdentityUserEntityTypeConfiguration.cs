using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess.Configuration
{
    /// <summary>
    /// The <see cref="IdentityUser"/> entity is part of Microsoft.AspNetCore.Identity.
    /// This configuration is to create a relation with custom entities.
    /// </summary>
    internal class IdentityUserEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            // Create relation between the User and User Settings
            builder.HasOne<UserSettings>()
                   .WithOne()
                   .HasForeignKey<UserSettings>("UserId");
        }
    }
}
