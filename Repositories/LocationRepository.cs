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
    public class LocationRepository : ILocationRepository
    {
      private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.Locations.Include(l => l.Weathers).ToListAsync();
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await _context.Locations
                .Include(l => l.Weathers)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}