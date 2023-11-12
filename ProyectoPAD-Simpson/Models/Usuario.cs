using System.ComponentModel.DataAnnotations;

namespace ProyectoPADSimpson.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
    }
}
