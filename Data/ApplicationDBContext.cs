using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public DbSet<Occupancy> Occupancy { get; set; }

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
                    Id = Guid.Parse("019a458b-cf46-73ec-9dfc-7128d83ad0d9"),
                    Name = "Abergue 1",
                    Latitude = -52.4573,
                    Longitude = 17.9274,
                    Capacity = 100,
                    Address = "Dirección de prueba",
                    Municipality = (Municipalities)1,
                    Available = true,
                    CreatedAt = new DateTime(2025, 11, 2),
                    Deleted = false,
                },
                new Shelter
                {
                    Id = Guid.Parse("019a458d-21a4-738b-b3dd-ed782a432da7"),
                    Name = "Abergue 2",
                    Latitude = 19.4130,
                    Longitude = -20.5908,
                    Capacity = 200,
                    Address = "Otra dirección de prueba",
                    Municipality = (Municipalities)1,
                    Available = true,
                    CreatedAt = new DateTime(2025, 11, 2),
                    Deleted = false,
                },
                new Shelter
                {
                    Id = Guid.Parse("019a458d-51e2-799a-9e57-96718c3e7d1f"),
                    Name = "Abergue 3",
                    Latitude = -63.5023,
                    Longitude = 79.4678,
                    Capacity = 300,
                    Address = "Otra otra dirección de prueba",
                    Municipality = (Municipalities)1,
                    Available = true,
                    CreatedAt = new DateTime(2025, 11, 2),
                    Deleted = false,
                }
            };
      builder.Entity<Shelter>().HasData(shelters);
    }
  }
}