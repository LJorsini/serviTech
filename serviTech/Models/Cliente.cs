using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serviTech.Models {
    public class Cliente : Persona {
        [NotMapped]
        public int IdCliente {get;set;}
        public int IdPersona {get;set;}

        public virtual Persona Personas {get;set;}
        

    }
}