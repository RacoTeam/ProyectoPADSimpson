using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Server.Interfaces
{
    public interface IFraseServicio
    {
        public List<FraseDTO> GetFraseDetails();
        public void AddFrase(FraseDTO Frase);
        public void UpdateFraseDetails(FraseDTO Frase);
        public FraseDTO GetFraseData(int id);
        public void DeleteFrase(int id);
    }
}
