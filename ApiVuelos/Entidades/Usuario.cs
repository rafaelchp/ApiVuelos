using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [StringLength(maximumLength: 255)]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength: 255)]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
