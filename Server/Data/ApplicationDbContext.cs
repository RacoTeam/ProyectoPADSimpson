using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Shared.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder) { }

    public DbSet<UsuarioDTO> Usuarios { get; set; }
    public DbSet<FraseDTO> Frases { get; set; }
}
