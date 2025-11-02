using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SafeMapQROOBackend.Models
{
    public class Shelter
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Name { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [MunicipalityValidator(ErrorMessage = "Invalid Municipality")]
        public Municipalities Municipality { get; set; }
        public bool Available { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Deleted { get; set; } = false;
    }

    public enum Municipalities
    {
        [Description("Cozumel")]
        Cozumel,
        [Description("Felipe Carrillo Puerto")]
        FelipeCarrilloPuerto,
        [Description("Isla Mujeres")]
        IslaMujeres,
        [Description("Othón P. Blanco")]
        OthonPBlanco,
        [Description("Benito Juarez")]
        BenitoJuarez,
        [Description("José Maria Morelos")]
        JoseMariaMorelos,
        [Description("Lázaro Cardenas")]
        LazaroCardenas,
        [Description("Playa Del Carmen")]
        PlayaDelCarmen,
        [Description("Tulum")]
        Tulum,
        [Description("Bacalar")]
        Bacalar,
        [Description("Puerto Morelos")]
        PuertoMorelos
    }

    public class MunicipalityValidator : ValidationAttribute
    {
        private static readonly List<Municipalities> ValidMunicipalities = new List<Municipalities>
        {
            Municipalities.Cozumel,
            Municipalities.FelipeCarrilloPuerto,
            Municipalities.IslaMujeres,
            Municipalities.OthonPBlanco,
            Municipalities.BenitoJuarez,
            Municipalities.JoseMariaMorelos,
            Municipalities.LazaroCardenas,
            Municipalities.PlayaDelCarmen,
            Municipalities.Tulum,
            Municipalities.Bacalar,
            Municipalities.PuertoMorelos
        };

        public override bool IsValid(object value)
        {
            if (value is Municipalities municipality)
            {
                return ValidMunicipalities.Contains(municipality);
            }
            return false;
        }
    }
}