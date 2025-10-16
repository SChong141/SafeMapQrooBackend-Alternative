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
                Nombre = shelterModel.Nombre,
                Latidud = shelterModel.Latidud,
                Longitud = shelterModel.Longitud,
                Capacidad = shelterModel.Capacidad,
                Ocupantes = shelterModel.Ocupantes,
                Direccion = shelterModel.Direccion,
                Disponible = shelterModel.Disponible,
            };
        }

        /*public static ToShelterFromCreateDto(ThisExpressionSyntax CreateShelterRequestDto)
        {
            return new Shelter
            {
                
            }
        }*/
    }
}