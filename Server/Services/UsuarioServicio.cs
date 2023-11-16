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
        public List<UsuarioDTO> GetUsuarioDetails()
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
        public void AddUsuario(UsuarioDTO Usuario)
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
        public void UpdateUsuarioDetails(UsuarioDTO Usuario)
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
        public UsuarioDTO GetUsuarioData(int id)
        {
            try
            {
                UsuarioDTO? Usuario = _dbContext.Usuarios.Find(id);
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
                UsuarioDTO? Usuario = _dbContext.Usuarios.Find(id);
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
