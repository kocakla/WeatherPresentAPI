using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using WeatherPresentAPI.Models;

namespace WeatherPresentAPI.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // One-To-many
            builder.Entity<Location>()
            .HasMany(l => l.Weathers)
            .WithOne(w => w.Location)
            .HasForeignKey(w => w.LocationId);

            builder.Entity<Weather>()
            .Property(w => w.WindDirection)
            .HasConversion<string>();

            builder.Entity<Weather>()
            .Property(w => w.WindSpeed)
            .HasConversion<string>();
        }
    }
}