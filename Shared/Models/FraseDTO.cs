using System.ComponentModel.DataAnnotations;

namespace ProyectoPADSimpson.Shared.Models
{
    public class FraseDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
        public string Episodio { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public string Personaje { get; set; }
    }
}
