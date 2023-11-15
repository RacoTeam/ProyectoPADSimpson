using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Server.Interfaces;
using ProyectoPADSimpson.Shared.Models;

namespace ProyectoPADSimpson.Server.Services
{
    public class UsuarioServicio : IUsuarioServicio
    {
        readonly ApplicationDbContext _dbContext;
        public UsuarioServicio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all Usuario details
        public List<Usuario> GetUsuarioDetails()
        {
            try
            {
                return _dbContext.Usuarios.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new Usuario record
        public void AddUsuario(Usuario Usuario)
        {
            try
            {
                _dbContext.Usuarios.Add(Usuario);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar Usuario
        public void UpdateUsuarioDetails(Usuario Usuario)
        {
            try
            {
                _dbContext.Entry(Usuario).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular Usuario
        public Usuario GetUsuarioData(int id)
        {
            try
            {
                Usuario? Usuario = _dbContext.Usuarios.Find(id);
                if (Usuario != null)
                {
                    return Usuario;
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
        //To Delete the record of a particular Usuario
        public void DeleteUsuario(int id)
        {
            try
            {
                Usuario? Usuario = _dbContext.Usuarios.Find(id);
                if (Usuario != null)
                {
                    _dbContext.Usuarios.Remove(Usuario);
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
