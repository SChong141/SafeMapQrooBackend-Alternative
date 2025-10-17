using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROOBackend.Dtos.Shelter
{
    public class UpdateShelterRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public double Latidude { get; set; }
        public double Longitude { get; set; }
        public int Capacity { get; set; }
        public int Occupants { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool Available { get; set; }
    }
}