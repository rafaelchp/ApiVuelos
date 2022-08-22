using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.DTO
{
    public class UserLoginDTO
    {
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength: 255)]
        public string Password { get; set; }
    }
}
