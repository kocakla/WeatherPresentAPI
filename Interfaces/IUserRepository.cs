using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherPresentAPI.Models;

namespace WeatherPresentAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}