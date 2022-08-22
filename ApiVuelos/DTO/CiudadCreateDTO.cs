using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.DTO
{
    public class CiudadCreateDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Ciudad { get; set; }
    }
}
