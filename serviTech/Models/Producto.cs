using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using serviTech.Migrations;

namespace serviTech.Models {
    public class Producto {
        [Key]
        public int ProductoID {get; set;}
        public string Nombre {get; set;}
        public string? Descripcion {get;set;}
        public decimal Precio {get; set;}
        public int? StockActual {get; set;}
        public int? StockMinimo {get;set;}

        public ICollection<MovimientoStock> MovimientosStock {get;set;}
    }
}