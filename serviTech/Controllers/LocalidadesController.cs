using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using serviTech.Data;
using serviTech.Models;

namespace serviTech.Controllers;

public class LocalidadesController : Controller
{

    private ApplicationDbContext _context;

    public LocalidadesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var provincias = _context.Provincias.ToList();
        /* var buscarProvincias = provincias.ToList(); */

        provincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[SELECCIONE...]" });
        /* buscarProvincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[Todas las Provincias]" }); */

        ViewBag.ProvinciaID = new SelectList(provincias, "ProvinciaID", "NombreProvincia");
        /* ViewBag.buscarProvincias = new SelectList(buscarProvincias, "ProvinciaID", "NombreProvincia"); */

        return View();

    }

    /*public IActionResult GuardarLocalidad(int localidadID, int provinciaID, string nombreLocalidad, int cp)
    {
        string resultado = "";

        if(!String.IsNullOrEmpty(nombreLocalidad))
        {
            if (localidadID == 0)
            {
                var existeLocalidad = _context.Localidades.Where(t => t.NombreLocalidad == nombreLocalidad).Count();
                if (existeLocalidad == 0)
                {
                    var nuevaLocalidad = new Localidad
                    {
                        ProvinciaID = provinciaID,
                        NombreLocalidad = nombreLocalidad.ToUpper(),
                        Cp = cp,
                    };
                    _context.Localidades.Add(nuevaLocalidad);
                    _context.SaveChanges();
                }
                else
                {
                    resultado = "Ya existe un registro con ese nombre";
                }
            }
            else
            {
                var editarLocalidad = _context.Localidades.Where(t => t.LocalidadID == localidadID).SingleOrDefault();
                if (editarLocalidad != null)
                {
                    var existeLocalidad = _context.Localidades.Where(t => t.NombreLocalidad == nombreLocalidad && t.LocalidadID != localidadID).Count();

                    if (existeLocalidad == 0)
                    {
                        editarLocalidad.ProvinciaID = provinciaID;
                        editarLocalidad.NombreLocalidad = nombreLocalidad.ToUpper();
                        editarLocalidad.Cp = cp;
                        _context.SaveChanges();
                    }
                    else
                    {
                        resultado = "YA EXISTE";
                    }
                }
                else
                {
                    resultado = "Debe ingresar un nombre";
                }
            }
        }
        else {
            resultado = "Hay un campo vacio";
        }

        return Json(resultado);
    } */

    public JsonResult GuardarLocalidad(int localidadID, int provinciaID, string? nombreLocalidad, string cp)
    {
        string resultado = "";
        

        if (localidadID == 0)
        {
            var localidad = new Localidad
            {
                NombreLocalidad = nombreLocalidad,
                Cp = cp,
                ProvinciaID = provinciaID,
                
            };
            _context.Add(localidad);
            _context.SaveChanges();

            resultado = "EL REGISTRO SE GUARDO CORRECTAMENTE";
        }
         else
         {
             var editarLocalidad = _context.Localidades.Where(e => e.LocalidadID == localidadID).SingleOrDefault();
             if (editarLocalidad != null)
             {
                 editarLocalidad.LocalidadID = localidadID;
                 editarLocalidad.NombreLocalidad = nombreLocalidad;
                 editarLocalidad.Cp = cp;
                 editarLocalidad.ProvinciaID = provinciaID;
                 _context.SaveChanges();

                 resultado = "EL REGISTRO SE ACTUALIZÓ CORRECTAMENTE";
             }
         }
        return Json(resultado);
    }



    public IActionResult Lista(int? id, int? provinciaID)
    {

        var localidades = _context.Localidades.Include(t => t.Provincias).ToList();

        var mostrarLocalidad = localidades.Select(e => new VistaLocalidad
        {
            LocalidadID = e.LocalidadID,
            ProvinciaID = e.ProvinciaID,
            NombreProvincia = e.Provincias.NombreProvincia,
            NombreLocalidad = e.NombreLocalidad,
            Cp = e.Cp
        }
        );


        return Json(mostrarLocalidad);
    }


    public IActionResult Eliminar(int localidadID)
    {
        var localidadEliminada = _context.Localidades.Find(localidadID);
        _context.Remove(localidadEliminada);
        _context.SaveChanges();

        return Json(localidadEliminada);
    }

}



