using System.ComponentModel.DataAnnotations;

namespace serviTech.Models {
    public class Localidad {
        [Key]
        public int IdLocalidad {get;set;}
        public string? Nombre {get;set;}
        public int Cp {get;set;}

        public virtual Provincia Provincias {get;set;} 
    }
}