using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace serviTech.Models {
    public class Empleado: Persona {
        [NotMapped]
        public int IdEmpleado {get;set;}
        public int IdPersona {get;set;}
        
        public virtual Persona Personas {get;set;}

    }
}