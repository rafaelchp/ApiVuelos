using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.Entidades
{
    public class Aerolinea
    {
        public int Id { get; set; }
        [Required]
        public string NombreAerolinea { get; set; }
        public List<VuelosAerolinea> vuelosAerolinea { get; set; }
    }
}
