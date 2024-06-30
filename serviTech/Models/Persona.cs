using System.ComponentModel.DataAnnotations;


namespace serviTech.Models {
    public class Persona {
        
        public int Id{get; set;}
        public string? Nombre {get; set;}
        public string? Apellido {get;set;}
        public string? Direccion {get;set;}
        public int IdLocalidad {get;set;}
        public int IdProvincia {get;set;}
        public string? Email {get;set;}
        public int? Telefono {get;set;}
        public int? Dni {get;set;}

        public virtual ICollection<Cliente> Clientes {get;set;}
        public virtual ICollection<Empleado> Empleados {get;set;}
    }
}