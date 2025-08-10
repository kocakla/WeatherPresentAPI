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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;
        public UserRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<User?> GetByUsernameAsync(string username) => 
          await _ctx.Users.SingleOrDefaultAsync(u => u.Username == username);
        
        public async Task AddAsync(User user) => await _ctx.Users.AddAsync(user);

        public async Task SaveChangesAsync() => await _ctx.SaveChangesAsync();

       

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
