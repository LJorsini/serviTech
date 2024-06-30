using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using serviTech.Data;
using serviTech.Models;


namespace serviTech.Controllers;

public class ClientesController : Controller
{
     private ApplicationDbContext _context;

    public ClientesController(ApplicationDbContext context)
    {
        _context = context;
    }

     public IActionResult Index()
    {
        var provincias = _context.Provincias.ToList();
        var provinciasListItems = provincias.Select(p => new SelectListItem
        {
            Value = p.IdProvincia.ToString(),
            Text = p.Nombre
        }).ToList();

        ViewBag.Provincias = provinciasListItems;
        return View();
    }
    
}