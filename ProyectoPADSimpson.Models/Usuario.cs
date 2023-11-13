using System;
using System.Collections.Generic;

namespace ProyectoPADSimpson.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Clave { get; set; }

    public virtual ICollection<Frase> Frases { get; set; } = new List<Frase>();
}
