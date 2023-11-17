using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Client.Services
{
    public interface IFraseServicio
    {
        Task<List<FraseDTO>> ObtenerFrasesDelUsuario(int idUsuario);
        Task<FraseDTO> ObtenerFrase(int id);
        Task<int> AgregarFrase(FraseDTO Frase);
        Task<bool> EliminarFrase(int id);
    }
}
