using System.ComponentModel.DataAnnotations;

namespace serviTech.Models {
    public class Localidad {
        [Key]
        public int LocalidadID {get;set;}
        public int ProvinciaID {get; set;}
        public string? NombreLocalidad {get;set;}
        public int Cp {get;set;}

        public virtual Provincia Provincias {get;set;} 
        public virtual Cliente Clientes {get; set;}
    }

    public class VistaLocalidad {
        public int LocalidadID {get;set;}
        public int ProvinciaID {get;set;}
        public string? NombreProvincia {get; set;}
        public string? NombreLocalidad {get; set;}
        public int Cp {get;set;}
    }
}