using System.ComponentModel.DataAnnotations;

namespace ProyectoPADSimpson.Shared.Models
{
    public class UsuarioDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Username { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }
    }
}
