using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Models;
using ProyectoPADSimpson.Servicio;

namespace Ecommerce.Servicio.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {

        public UsuarioServicio()
        {
        }

        public Task<Usuario> Crear(Usuario modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Usuario modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> Lista(string rol, string buscar)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Obtener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
