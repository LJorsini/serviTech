/* using System.ComponentModel.DataAnnotations;


namespace serviTech.Models {
    public class Persona {
        [Key]
        public int ClienteId {get; set;}
        public string? Nombre {get; set;}
        public string? Apellido {get;set;}
        public string? Direccion {get;set;}
        public int LocalidadID {get;set;}
        public int ProvinciaID {get;set;}
        public int CP {get;set;}
        public string? Email {get;set;}
        public int? Telefono {get;set;}
        public int? Dni {get;set;}

        public virtual ICollection<Cliente> Clientes {get;set;}
        public virtual ICollection<Empleado> Empleados {get;set;}
    }
} */