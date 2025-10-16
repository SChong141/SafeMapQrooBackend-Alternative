using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SafeMapQROOBackend.Dtos.Shelter;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Mappers
{
    public static class ShelterMappers
    {
        public static ShelterDTO ToShelterDTO(this Shelter shelterModel)
        {
            return new ShelterDTO
            {
                Id = shelterModel.Id,
                Name = shelterModel.Name,
                Latitude = shelterModel.Latitude,
                Longitude = shelterModel.Longitude,
                Capacity = shelterModel.Capacity,
                Occupants = shelterModel.Occupants,
                Address = shelterModel.Address,
                Available = shelterModel.Available,
            };
        }

        public static Shelter ToShelterFromCreateDTO(this CreateShelterRequestDTO shelterDTO)
        {
            return new Shelter
            {
                Name = shelterDTO.Name,
                Latitude = shelterDTO.Latidude,
                Longitude = shelterDTO.Longitude,
                Capacity = shelterDTO.Capacity,
                Address = shelterDTO.Address,
                Available = shelterDTO.Available
            };
        }
    }
}