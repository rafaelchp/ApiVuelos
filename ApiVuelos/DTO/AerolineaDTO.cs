using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.DTO
{
    public class AerolineaDTO
    {
        public int Id { get; set; }
        [Required]
        public string NombreAerolinea { get; set; }
    }
}
