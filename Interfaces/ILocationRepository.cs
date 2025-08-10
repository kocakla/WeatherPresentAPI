using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherPresentAPI.Models;

namespace WeatherPresentAPI.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location?> GetByIdAsync(int id);
        Task AddAsync(Location location);
        Task SaveAsync();   
    }
}