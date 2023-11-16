using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Server.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Frase> Frases { get; set; }
}
