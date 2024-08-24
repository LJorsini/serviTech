using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serviTech.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public string? Nombre {get; set;}
        public string? Apellido {get;set;}
        public string? Direccion {get;set;}
        public int LocalidadID {get;set;}
        public string? Email {get;set;}
        public int? Telefono {get;set;}
        public int Dni {get;set;}
        public virtual Localidad Localidades {get;set;} 
        
    }

    public class VistaCliente {
        public int ClienteID { get; set; }
        public string? Nombre {get; set;}
        public string? Apellido {get;set;}
        public string? Direccion {get;set;}
        public int LocalidadID {get;set;}
        public int NombreLocalidad {get; set;}
        public string? Email {get;set;}
        public int? Telefono {get;set;}
        public int? Dni {get;set;}
    }
}