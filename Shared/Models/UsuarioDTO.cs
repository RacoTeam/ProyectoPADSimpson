using System.ComponentModel.DataAnnotations;

namespace ProyectoPADSimpson.Shared.Models
{
    public class UsuarioDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre de usuario es requerido")]
        public string Username { get; set; }
        [Required(ErrorMessage = "El campo contraseña es requerido")]
        public string Password { get; set; }
    }
}
