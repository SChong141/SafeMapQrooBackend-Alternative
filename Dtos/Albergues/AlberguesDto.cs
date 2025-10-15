using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROOBackend.Dtos.Albergues
{
    public class AlberguesDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double Latidud { get; set; }
        public double Longitud { get; set; }
        public int Capacidad { get; set; }
        public int Ocupantes { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public bool Disponible { get; set; }
    }
}