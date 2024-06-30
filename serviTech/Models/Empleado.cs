using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace serviTech.Models {
    public class Empleado : Persona
    {
        
        
        public Persona Persona {get;set;}
    }
}