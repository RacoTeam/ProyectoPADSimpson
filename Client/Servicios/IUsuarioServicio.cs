using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Client.Servicio
{
    public interface IUsuarioServicio
    {
        Task<List<Usuario>> Lista(string rol, string buscar);
        Task<Usuario> Obtener(int id);
        //Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);

        Task<Usuario> Crear(Usuario modelo);
        Task<bool> Editar(Usuario modelo);
    }
}
