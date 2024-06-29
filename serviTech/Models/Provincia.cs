using System.ComponentModel.DataAnnotations;

namespace serviTech.Models {
    public class Provincia {
        [Key]
        public int IdProvincia {get; set;}
        public string? Nombre {get;set;}

        public virtual ICollection<Localidad> Localidades {get;set;}
    }
}