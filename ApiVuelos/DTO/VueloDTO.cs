using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.DTO
{
    public class VueloDTO
    {

        public int Id { get; set; }
        public DateTime FechaVuelo { get; set; }
        [Required]
        public string HoraSalida { get; set; }
        [Required]
        public string HoraLlegada { get; set; }
        [Required]
        public string NumVuelo { get; set; }
        public string EstadoVuelo { get; set; }

        public List<AerolineaDTO> aerolineaDTOs { get; set; }
        public List<CiudadDTO> ciudadDTOs { get; set; }
    }
}
