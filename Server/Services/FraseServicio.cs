using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Server.Interfaces;
using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Server.Services
{
    public class FraseServicio : IFraseServicio
    {
        readonly ApplicationDbContext _dbContext;
        public FraseServicio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all Frase details
        public List<Frase> GetFraseDetails()
        {
            try
            {
                return _dbContext.Frases.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new Frase record
        public void AddFrase(Frase Frase)
        {
            try
            {
                _dbContext.Frases.Add(Frase);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar Frase
        public void UpdateFraseDetails(Frase Frase)
        {
            try
            {
                _dbContext.Entry(Frase).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular Frase
        public Frase GetFraseData(int id)
        {
            try
            {
                Frase? Frase = _dbContext.Frases.Find(id);
                if (Frase != null)
                {
                    return Frase;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular Frase
        public void DeleteFrase(int id)
        {
            try
            {
                Frase? Frase = _dbContext.Frases.Find(id);
                if (Frase != null)
                {
                    _dbContext.Frases.Remove(Frase);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
