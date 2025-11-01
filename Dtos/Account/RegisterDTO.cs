using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROOBackend.Dtos.Account
{
    public class RegisterDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public AllowedRoles Role { get; set; }
    }

    public enum AllowedRoles
    {
        Admin = 1,
        Organizer = 2,
    }
}