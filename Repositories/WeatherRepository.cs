using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherPresentAPI.Database;
using WeatherPresentAPI.Interfaces;
using WeatherPresentAPI.Models;

namespace WeatherPresentAPI.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly AppDbContext _context;

        public WeatherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Weather>> GetAllAsync()
        {
            return await _context.Weathers.Include(w => w.Location).ToListAsync();
        }

        public async Task<Weather?> GetByIdAsync(int id)
        {
            return await _context.Weathers
                .Include(w => w.Location)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task AddAsync(Weather weather)
        {
            await _context.Weathers.AddAsync(weather);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}