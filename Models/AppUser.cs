using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SafeMapQROOBackend.Models
{
    public class AppUser : IdentityUser
    {
        public Guid AssignedShelter { get; set; }
    }
}