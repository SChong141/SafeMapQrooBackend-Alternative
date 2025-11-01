using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        
        public DbSet<Shelter> Shelter { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Organizer",
                    NormalizedName = "ORGANIZER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            List<Shelter> shelters = new List<Shelter>
            {
                new Shelter
                {
                    Id = 1,
                    Name = "Abergue 1",
                    Latitude = -52.4573,
                    Longitude = 17.9274,
                    Capacity = 100,
                    Occupants = 0,
                    Address = "Dirección de prueba",
                    Available = true,
                    Deleted = false,
                },
                new Shelter
                {
                    Id = 2,
                    Name = "Abergue 2",
                    Latitude = 19.4130,
                    Longitude = -20.5908,
                    Capacity = 200,
                    Occupants = 0,
                    Address = "Otra dirección de prueba",
                    Available = true,
                    Deleted = false,
                },
                new Shelter
                {
                    Id = 3,
                    Name = "Abergue 3",
                    Latitude = -63.5023,
                    Longitude = 79.4678,
                    Capacity = 300,
                    Occupants = 0,
                    Address = "Otra otra irección de prueba",
                    Available = true,
                    Deleted = false,
                }
            };
            builder.Entity<Shelter>().HasData(shelters);
        }
    }
}