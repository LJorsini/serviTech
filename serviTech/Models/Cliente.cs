using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serviTech.Models {
    public class Cliente : Persona {
        
        
        public Persona Persona {get; set;}

     }
}