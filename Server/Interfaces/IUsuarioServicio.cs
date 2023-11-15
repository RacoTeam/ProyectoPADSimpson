using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Server.Interfaces
{
    public interface IUsuarioServicio
    {
        public List<Usuario> GetUsuarioDetails();
        public void AddUsuario(Usuario usuario);
        public void UpdateUsuarioDetails(Usuario usuario);
        public Usuario GetUsuarioData(int id);
        public void DeleteUsuario(int id);
    }
}
