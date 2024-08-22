using System.ComponentModel.DataAnnotations;

namespace serviTech.Models {
    public class Provincia {
        [Key]
        public int ProvinciaID {get; set;}
        public string? NombreProvincia {get;set;}

        public virtual ICollection<Localidad> Localidades {get;set;}
        public virtual ICollection<Cliente> Clientes {get; set;}
        public virtual ICollection<Empleado> Empleados {get; set;}
    }
}