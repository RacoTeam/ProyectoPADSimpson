using Microsoft.EntityFrameworkCore;
//using ProyectoPADSimpson.Models;

namespace ProyectoPADSimpson.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        //public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Frases> Frases { get; set; }

    }
}
