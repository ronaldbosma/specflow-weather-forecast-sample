using Microsoft.EntityFrameworkCore;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess
{
    internal class LocationRepository : ILocationRepository
    {
        private readonly WeatherForecastDbContext _context;

        public LocationRepository(WeatherForecastDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.Locations.ToListAsync();
        }
    }
}
