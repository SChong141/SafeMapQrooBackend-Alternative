using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROOBackend.Dtos.Occupancy;
using SafeMapQROOBackend.Dtos.User;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Dtos.Shelter
{
    public class ShelterDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; } = string.Empty;
        public Municipalities Municipality { get; set; }
        public bool Available { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OccupancyDTO> Occupancy { get; set; }
        public UserDTO Organizer { get; set; }
    }
}