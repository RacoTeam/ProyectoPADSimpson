using System.ComponentModel.DataAnnotations;

namespace ProyectoPADSimpson.Shared.Models
{
    public class FraseDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
        [Required]
        public string Capitulo { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}
