using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoPADSimpson.Models;

namespace ProyectoPADSimpson.Servicio
{
    public interface IUsuarioServicio
    {
        Task<List<Usuario>> Lista(string rol, string buscar);
        Task<Usuario> Obtener(int id);
        Task<Usuario> Crear(Usuario modelo);
        Task<bool> Editar(Usuario modelo);
        Task<bool> Eliminar(int id);
    }
}
