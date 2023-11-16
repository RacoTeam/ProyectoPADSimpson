using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Client.Servicios
{
    public interface IUsuarioServicio
    {
        Task<UsuarioDTO> Buscar(int id);
        Task<int> Guardar(UsuarioDTO empleado);
    }
}