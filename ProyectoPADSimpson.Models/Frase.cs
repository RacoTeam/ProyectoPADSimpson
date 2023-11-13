using System;
using System.Collections.Generic;

namespace ProyectoPADSimpson.Models;

public partial class Frase
{
    public int IdFrases { get; set; }

    public int? IdUsuario { get; set; }

    public string? Frase1 { get; set; }

    public string? Capitulo { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
