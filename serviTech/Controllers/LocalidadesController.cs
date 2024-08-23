using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        var buscarProvincias = provincias.ToList();

        provincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[SELECCIONE...]" });
        buscarProvincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[Todas las Provincias]" });

        ViewBag.ProvinciaID = new SelectList(provincias, "ProvinciaID", "NombreProvincia");
        ViewBag.buscarProvincias = new SelectList(buscarProvincias, "ProvinciaID", "NombreProvincia");

        return View();

    }

    public IActionResult GuardarLocalidad(int localidadID, int provinciaID, string nombreLocalidad, int cp)
    {
        string resultado = "";
        
        if (!String.IsNullOrEmpty(nombreLocalidad))
        {
            if (localidadID == 0)
            {
                var existeLocalidad = _context.Localidades.Where(t => t.NombreLocalidad == nombreLocalidad).Count();
                if (existeLocalidad == 0)
                {
                    var nuevaLocalidad = new Localidad{
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
                if (editarLocalidad !=  null)
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
                else{
                    resultado = "Debe ingresar un nombre";
                }
            }
        }
        
        return Json(resultado);
    }
    








}


