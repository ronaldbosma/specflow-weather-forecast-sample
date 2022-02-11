using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WeatherForecastSample.WebAPI.DataAccess.Configuration
{
    /// <summary>
    /// Value comparer for <see cref="DateOnly"/>, so we can use it as a property type with Entity Framework.
    /// </summary>
    public class DateOnlyComparer : ValueComparer<DateOnly>
    {
        public DateOnlyComparer() : base(
            (d1, d2) => d1.DayNumber == d2.DayNumber,
            d => d.GetHashCode())
        {
        }
    }
}
