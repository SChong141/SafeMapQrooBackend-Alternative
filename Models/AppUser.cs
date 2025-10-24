using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SafeMapQROO.Models
{
    public class AppUser : IdentityUser
    {

        public string Names { get; set; }
        public string Lastname { get; set; }
        public string? Curp { get; set; }
    }
}