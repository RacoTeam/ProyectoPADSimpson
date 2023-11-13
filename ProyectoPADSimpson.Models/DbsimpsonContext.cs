using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPADSimpson.Models;

public partial class DbsimpsonContext : DbContext
{
    public DbsimpsonContext()
    {
    }

    public DbsimpsonContext(DbContextOptions<DbsimpsonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Frase> Frases { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=DBSimpson; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Frase>(entity =>
        {
            entity.HasKey(e => e.IdFrases).HasName("PK__Frases__4CB337FC54A4115D");

            entity.Property(e => e.Capitulo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Frase1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Frase");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Frases)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Frases__IdUsuari__398D8EEE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97CE433239");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
