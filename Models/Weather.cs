using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherPresentAPI.Enums;

namespace WeatherPresentAPI.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public WindDirection WindDirection { get; set; }
        public WindSpeed WindSpeed { get; set; }
        public Location Location { get; set; } // Navigation property
    }
}