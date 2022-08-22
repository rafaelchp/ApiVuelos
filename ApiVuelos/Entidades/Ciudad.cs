using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.Entidades
{
    public class Ciudad
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string ciudad { get; set; }
        public List<VuelosCiudades> vuelosCiudades { get; set; }
    }
}
