using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.DTO
{
    public class AerolineaCreateDTO
    {

        [Required]
        public string NombreAerolinea { get; set; }
    }
}
