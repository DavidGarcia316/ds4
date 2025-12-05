using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial_3.Models 
{
    public class Expediente
    {
        public int IdCiudadano { get; set; }

        [Required]
        [Display(Name = "Cédula de Identidad")]
        public string CedulaIdentidad { get; set; }

        [Required]
        [Display(Name = "Nombres Completos")]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nac.")]
        public DateTime Nacimiento { get; set; }

        [Display(Name = "Correo (Opcional)")]
        public string CorreoElectronico { get; set; }

        public int IdTramite { get; set; }

        [Display(Name = "Estatus")]
        public string EstadoActual { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
    }
}