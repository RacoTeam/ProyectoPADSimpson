using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Server.Interfaces
{
    public interface IFraseServicio
    {
        public List<Frase> GetFraseDetails();
        public void AddFrase(Frase Frase);
        public void UpdateFraseDetails(Frase Frase);
        public Frase GetFraseData(int id);
        public void DeleteFrase(int id);
    }
}
