using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SafeMapQROOBackend.Dtos.Occupancy;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Mappers
{
    public static class OccupancyMapper
    {
        public static OccupancyDTO ToOccupancyDTO(this Occupancy occupancyModel)
        {
            return new OccupancyDTO
            {
                Id = occupancyModel.Id,
                CurrentOccupancy = occupancyModel.CurrentOccupancy,
                UpdatedOn = occupancyModel.UpdatedOn,
                ShelterId = occupancyModel.ShelterId
            };
        }

        public static Occupancy ToOccupancyFromCreateDTO(this CreateOccupancyRequestDTO occupancyDTO, Guid shelterId)
        {
            return new Occupancy
            {
                CurrentOccupancy = occupancyDTO.CurrentOccupancy,
                ShelterId = shelterId
            };
        }
    }
}