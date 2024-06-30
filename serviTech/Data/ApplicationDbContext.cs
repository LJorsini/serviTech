using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using serviTech.Models;

namespace serviTech.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Persona> Personas {get;set;}
    public DbSet<Cliente> Clientes {get;set;}
    public DbSet<Empleado> Empleados {get;set;}
    public DbSet<Provincia> Provincias {get;set;}
    public DbSet<Localidad> Localidades {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>()
                .HasBaseType<Persona>();

            modelBuilder.Entity<Cliente>()
                .HasBaseType<Persona>();

            // Esto permite que no se eliminen tablas en cascada
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Persona)
                .WithMany()
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.NoAction);
                

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Persona)
                .WithMany()
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.NoAction);
                
        }
}
