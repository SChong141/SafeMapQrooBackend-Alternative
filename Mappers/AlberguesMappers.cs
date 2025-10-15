using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SafeMapQROOBackend.Dtos.Albergues;
using SafeMapQROOBackend.Models;

namespace SafeMapQROOBackend.Mappers
{
    public static class AlberguesMappers
    {
        public static AlberguesDto ToAlberguesDTO(this Albergues albergesModel)
        {
            return new AlberguesDto
            {
                Id = albergesModel.Id,
                Nombre = albergesModel.Nombre,
                Latidud = albergesModel.Latidud,
                Longitud = albergesModel.Longitud,
                Capacidad = albergesModel.Capacidad,
                Ocupantes = albergesModel.Ocupantes,
                Direccion = albergesModel.Direccion,
                Disponible = albergesModel.Disponible,
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