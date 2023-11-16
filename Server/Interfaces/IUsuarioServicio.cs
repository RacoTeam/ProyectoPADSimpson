using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Server.Interfaces
{
    public interface IUsuarioServicio
    {
        public List<UsuarioDTO> GetUsuarioDetails();
        public void AddUsuario(UsuarioDTO usuario);
        public void UpdateUsuarioDetails(UsuarioDTO usuario);
        public UsuarioDTO GetUsuarioData(int id);
        public void DeleteUsuario(int id);
    }
}
