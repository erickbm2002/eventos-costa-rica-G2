using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoWebAvanzadaG2.Domain.Entities;

namespace ProyectoWebAvanzadaG2.Infraestructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //para que no se rompan las tablas de Identity

            //Configuración para evitar el error de "múltiples rutas en cascada" en SQL Server
            builder.Entity<Boleto>()
                .HasOne(b => b.Evento)
                .WithMany(e => e.Boletos)
                .HasForeignKey(b => b.EventoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Boleto>()
                .HasOne(b => b.Asiento)
                .WithMany()
                .HasForeignKey(b => b.AsientoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}