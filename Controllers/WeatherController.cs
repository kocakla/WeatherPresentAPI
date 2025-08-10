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
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepo;
        private readonly IMapper _mapper;

        public WeatherController(IWeatherRepository weatherRepo, IMapper mapper)
        {
            _weatherRepo = weatherRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherDto>>> GetWeather()
        {
            var weathers = await _weatherRepo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<WeatherDto>>(weathers));
        }

        [HttpPost]
        public async Task<ActionResult<WeatherDto>> AddWeather([FromBody] CreateWeatherDto createDto)
        {
            var weather = _mapper.Map<Weather>(createDto);
            await _weatherRepo.AddAsync(weather);
            await _weatherRepo.SaveAsync();

            var weatherDto = _mapper.Map<WeatherDto>(weather);
            return CreatedAtAction(nameof(GetWeather), new { id = weatherDto.Id }, weatherDto);
        }

    }
}