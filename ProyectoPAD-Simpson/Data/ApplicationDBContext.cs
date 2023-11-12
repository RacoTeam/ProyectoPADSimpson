using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Models;

namespace ProyectoPADSimpson.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Frases> Frases { get; set; }

    }
}
