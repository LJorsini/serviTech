using System.ComponentModel.DataAnnotations;

namespace serviTech.Models {
    public class MovimientoStock {
        [Key]
        public int MovimientoID {get; set;}
        public int ProductoID {get;set;}
        public int StockActual {get; set;}
        public DateOnly FechaMovimiento {get;set;}
        public int Cantidad {get;set;}
        public bool TipoMovimiento {get;set;}
        public string? Observaciones {get;set;}
        public Producto Producto {get;set;}

    }

    public class VistaMovimiento {
        public int MovimientoID {get; set;}
        public int ProductoID {get;set;}
        public int StockActual {get; set;}
        public int StockMinimo {get; set;}
        public DateOnly FechaMovimiento {get;set;}
        public int Cantidad {get;set;}
        public bool TipoMovimiento {get;set;}
        public string? Observaciones {get;set;}
    }
}