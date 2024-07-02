using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace serviTech.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }
        public int PersonaID {get; set;}
        public Persona Persona { get; set; }
    }
}

