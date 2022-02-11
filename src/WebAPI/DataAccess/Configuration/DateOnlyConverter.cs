using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WeatherForecastSample.WebAPI.DataAccess.Configuration
{
    /// <summary>
    /// Value converter for <see cref="DateOnly"/>, so we can use it as a property type with Entity Framework.
    /// </summary>
    internal class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
        {
        }
    }
}
