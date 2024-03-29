﻿using Microsoft.AspNetCore.Authorization;
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
        public async Task<IEnumerable<Location>> GetLocations()
        {
            var locations = await _locationRepository.GetAllAsync();
            return locations.MapToModel();
        }

        [HttpGet("/api/locations/{id}")]
        public async Task<Location> GetLocation(int id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            return location.MapToModel();
        }
    }
}
