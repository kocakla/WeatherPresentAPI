using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Framework.Profiler;
using AutoMapper;
using WeatherPresentAPI.Models;
using WeatherPresentAPI.Dtos;

namespace WeatherPresentAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // Entity -> DTO
            CreateMap<Location, LocationDto>();
            CreateMap<Weather, WeatherDto>();

            // DTO -> Entity
            CreateMap<CreateLocationDto, Location>();
            CreateMap<CreateWeatherDto, Weather>();            
        }
        
    }
}