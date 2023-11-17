using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Client.Services
{
    public interface IUsuarioServicio
    {
        Task<bool> Buscar(UsuarioDTO empleado);
        Task<int> Guardar(UsuarioDTO empleado);
    }
}