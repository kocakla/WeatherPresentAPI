using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherPresentAPI.Models;

namespace WeatherPresentAPI.Interfaces
{
    public interface IWeatherRepository
    {
        Task<IEnumerable<Weather>> GetAllAsync();
        Task<Weather?> GetByIdAsync(int id);
        Task AddAsync(Weather weather);
        Task SaveAsync();
    }
}