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

        public IEnumerable<Location> GetAll()
        {
            return _context.Locations.ToList();
        }

        public Location GetById(int id)
        {
            var location = _context.Locations.Find(id);
            return location ?? throw new ArgumentException($"Unknown location id {id}", nameof(id));
        }
    }
}
