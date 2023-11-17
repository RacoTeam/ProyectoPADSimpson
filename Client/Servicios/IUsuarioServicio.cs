using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Client.Servicios
{
    public interface IUsuarioServicio
    {
        Task<bool> Buscar(UsuarioDTO empleado);
        Task<int> Guardar(UsuarioDTO empleado);
    }
}