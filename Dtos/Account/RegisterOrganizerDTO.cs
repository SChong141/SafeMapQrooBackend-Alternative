using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROOBackend.Dtos.Account
{
    public class RegisterOrganizerDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public Guid AssignedShelter { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}