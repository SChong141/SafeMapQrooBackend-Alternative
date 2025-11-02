using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Dtos.Shelter
{
    public class CreateShelterRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public double Latidude { get; set; }
        public double Longitude { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; } = string.Empty;
        public Municipalities Municipality { get; set; }
        public bool Available { get; set; }
    }
}