using Microsoft.AspNetCore.Mvc;
using serviTech.Data;
using serviTech.Models;

namespace serviTech.Controllers;

public class ProductosController : Controller {
    private ApplicationDbContext _context;

    public ProductosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() {
        return View();
    }

    public JsonResult Listado(int? productoID) {
        var productos = _context.Productos.ToList();

        if (productoID != null) {
            productos = _context.Productos.Where(p => p.ProductoID == productoID).ToList();
        }

        return Json(productos);

    }

   public JsonResult GuardarProducto(int productoID, string nombreProducto, string? descripcionProducto, decimal precio, int? stockMinimo)
    {
        
        string resultado = "";

        if (!String.IsNullOrEmpty(nombreProducto))
        {
            nombreProducto = nombreProducto.ToUpper();
            descripcionProducto = descripcionProducto.ToUpper();
            
            if (productoID == 0)
            {
               
                var existeProducto = _context.Productos.Where(t => t.Nombre == nombreProducto).Count();
                if (existeProducto == 0)
                {
                    //4- GUARDAR EL TIPO DE EJERCICIO
                    var producto = new Producto
                    {
                        Nombre = nombreProducto,
                        Descripcion = descripcionProducto,
                        Precio = precio,
                        StockActual = 0,
                        StockMinimo = stockMinimo,
                    };
                    _context.Add(producto);
                    _context.SaveChanges();
                }
                else
                {
                    resultado = "YA EXISTE UN REGISTRO CON LA MISMA DESCRIPCIÓN";
                }
            }
            else
            {
               
            }
        }
        else
        {
            resultado = "DEBE INGRESAR UNA DESCRIPCIÓN.";
        }

        return Json(resultado);
    }

    public JsonResult MovimientoStock(int productoMovimientoID, bool tipoMovimiento, int cantidad, int stockMinimo, DateOnly fechaMovimiento, string? observaciones) {
        
        string resultado = "";
        var producto = _context.Productos.FirstOrDefault(p => p.ProductoID == productoMovimientoID);

        producto.StockActual = producto.StockActual + cantidad;
        producto.StockMinimo = stockMinimo;

        var nuevoMovimiento = new MovimientoStock {
            
            TipoMovimiento = tipoMovimiento,
            ProductoID = productoMovimientoID,
            FechaMovimiento = fechaMovimiento,
            Cantidad = cantidad,
            Observaciones = observaciones,
            StockActual = producto.StockActual.Value, 
        

            
            
            };
            _context.Add(nuevoMovimiento);
            _context.SaveChanges();


        return Json (resultado);
    }

}