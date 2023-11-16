using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Client.Servicio
{
    public interface IUsuarioServicio
    {
        Task<UsuarioDTO> Buscar(int id);
        Task<int> Guardar(UsuarioDTO empleado);
    }
}