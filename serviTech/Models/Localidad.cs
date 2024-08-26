using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using serviTech.Migrations;

namespace serviTech.Models {
    public class Localidad {
        [Key]
        public int LocalidadID {get;set;}
        public int ProvinciaID {get; set;}
        public string? NombreLocalidad {get;set;}
        public int Cp {get;set;}

        public virtual Provincia Provincias {get;set;} 
        public virtual ICollection<Cliente> Clientes {get; set;}
    }

    public class VistaLocalidad {
        public int LocalidadID {get;set;}
        public int ProvinciaID {get;set;}
        public string? NombreProvincia {get; set;}
        public string? NombreLocalidad {get; set;}
        public int Cp {get;set;}
    }
}