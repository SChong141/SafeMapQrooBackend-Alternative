using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SafeMapQROO.Models;
using SafeMapQROOBackend.Models;


namespace SafeMapQROOBackend.Data
{
  public class ApplicationDBContext : IdentityDbContext<AppUser>
  {
    public ApplicationDBContext(DbContextOptions dbContextOptions)
    : base(dbContextOptions)
    {

    }

    public DbSet<Albergues> Albergues { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      List<IdentityRole> roles = new List<IdentityRole>
        {
          new IdentityRole
          {
            Id="1",
              Name = "Admin",
              NormalizedName="ADMIN"
          },
        new IdentityRole
        {
            Id="2",
              Name = "User",
              NormalizedName="USER"
          }
        };
      builder.Entity<IdentityRole>().HasData(roles);
    }
  }
}