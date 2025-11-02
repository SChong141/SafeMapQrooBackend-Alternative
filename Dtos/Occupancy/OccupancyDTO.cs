using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROOBackend.Dtos.Occupancy
{
    public class OccupancyDTO
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public int CurrentOccupancy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public Guid? ShelterId { get; set; }
    }
}