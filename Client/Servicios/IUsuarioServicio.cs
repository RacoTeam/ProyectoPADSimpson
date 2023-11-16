using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Client.Servicio
{
    public interface IUsuarioServicio
    {
        Task<List<UsuarioDTO>> Lista(string rol, string buscar);
        Task<UsuarioDTO> Obtener(int id);
        //Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);

        Task<UsuarioDTO> Crear(UsuarioDTO modelo);
        Task<bool> Editar(UsuarioDTO modelo);
    }
}
