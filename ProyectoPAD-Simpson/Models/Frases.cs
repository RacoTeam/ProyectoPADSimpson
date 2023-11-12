using System.ComponentModel.DataAnnotations;

namespace ProyectoPADSimpson.Models
{
    public class Frases
    {
        [Key]
        public int IdFrases { get; set; }
        public string Usuario { get; set; }
        public string Frase { get; set; }
        public string Capitulo { get; set; }
    }
}
