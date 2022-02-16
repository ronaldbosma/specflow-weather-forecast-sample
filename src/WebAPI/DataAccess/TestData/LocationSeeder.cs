using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.WebAPI.DataAccess.TestData
{
    internal class LocationSeeder
    {
        private readonly WeatherForecastDbContext _context;

        public LocationSeeder(WeatherForecastDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddLocation("Amsterdam");
            AddLocation("London");
            AddLocation("Madrid");

            _context.SaveChanges();
        }

        private void AddLocation(string location)
        {
            var locationDoesNotExist = !_context.Locations.Any(l => l.Name == location);
            if (locationDoesNotExist)
            {
                _context.Add(new Location { Name = location });
            }
        }
    }
}
