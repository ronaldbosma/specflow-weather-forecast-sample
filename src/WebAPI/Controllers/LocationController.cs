using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastSample.Shared.Models;
using WeatherForecastSample.WebAPI.Controllers.Mappers;
using WeatherForecastSample.WebAPI.DataAccess;

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
        public IEnumerable<Location> GetLocations()
        {
            var locations = _locationRepository.GetAll();
            return locations.MapToModel();
        }

        [HttpGet("/api/locations/{id}")]
        public Location GetLocation(int id)
        {
            var location = _locationRepository.GetById(id);
            return location.MapToModel();
        }
    }
}
