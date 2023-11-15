using System.ComponentModel.DataAnnotations;

namespace ProyectoPADSimpson.Shared.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Username { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ConfirmPassword { get; set; }
    }
}
