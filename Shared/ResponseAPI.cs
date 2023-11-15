using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPADSimpson.Shared
{
    public class ResponseAPI<T>
    {
        public bool esCorrecto  { get; set; }
        public T? Valor{ get; set; }
        public string? Mensaje { get; set; }
    }
}
