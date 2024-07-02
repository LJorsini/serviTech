using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serviTech.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public int PersonaID { get; set; }
        public Persona Persona { get; set; }

    }
}