using System;
using System.Collections.Generic;

namespace ProyectoPADSimpson.Server.Modelos;

public partial class Frase
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public string Capitulo { get; set; }
    public int IdUsuario { get; set; }
}