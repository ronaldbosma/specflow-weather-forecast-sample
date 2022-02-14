using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastSample.Shared.Models;
using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Mappers;

namespace WeatherForecastSample.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet("/api/locations")]
        public async Task<IEnumerable<Location>> GetLocations()
        {
            var locations = await _locationRepository.GetAllAsync();
            return locations.MapToModel();
        }
    }
}
