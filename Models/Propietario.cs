﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMunicipalidadTP.Models
{
    [Table("Propietario")]
  
    public class Propietario
    {
        [Key] public int IDPropietario { get; set; } // Clave primaria
        public string? ApeyNombre { get; set; }
        public int? Numdoc { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public DateTime? Fechanac { get; set; }
        public int? Cod_estado_Civil { get; set; }
        public required byte[] Clavedeacceso { get; set; }

        public CDest_civ? EstadoCivil { get; set; }
        public ICollection<BienPropietario>? BienesPropietarios { get; set; }
        public ICollection<PagoPropietario>? PagosPropietarios { get; set; }
    }
}
