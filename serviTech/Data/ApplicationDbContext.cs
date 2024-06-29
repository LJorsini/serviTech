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
}
