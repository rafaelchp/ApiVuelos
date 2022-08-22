using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.Entidades
{
    public class Vuelo
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

        public List<VuelosCiudades> vuelosCiudades { get; set; }
        public List<VuelosAerolinea> vuelosAerolinea { get; set; }
    }
}
