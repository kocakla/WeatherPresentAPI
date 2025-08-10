using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherPresentAPI.Database;
using WeatherPresentAPI.Dtos;
using WeatherPresentAPI.Interfaces;
using WeatherPresentAPI.Models;

namespace WeatherPresentAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepo;
        private readonly IMapper _mapper;

        public LocationController(ILocationRepository locationRepo, IMapper mapper)
        {
            _locationRepo = locationRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocations()
        {
            var locations = await _locationRepo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<LocationDto>>(locations));
        }

        [HttpPost]
        public async Task<ActionResult<LocationDto>> AddLocation(CreateLocationDto createDto)
        {
            var location = _mapper.Map<Location>(createDto);
            await _locationRepo.AddAsync(location);
            await _locationRepo.SaveAsync();

            var locationDto = _mapper.Map<LocationDto>(location);
            return CreatedAtAction(nameof(GetLocations), new { id = locationDto.Id }, locationDto);
        }
    }
}