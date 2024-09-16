using System.ComponentModel.DataAnnotations;

namespace serviTech.Models {
    public class MovimientoStock {
        [Key]
        public int MovimientoID {get; set;}
        public int ProductoID {get;set;}
        public DateOnly FechaMovimiento {get;set;}
        public int Cantidad {get;set;}
        public string TipoMovimiento {get;set;}
        public string? Observaciones {get;set;}
        public Producto Producto {get;set;}

    }
}