using Microsoft.AspNetCore.Mvc;
using serviTech.Data;

namespace serviTech.Controllers;

public class LocalidadesController : Controller {

    private ApplicationDbContext _context;

    public LocalidadesController(ApplicationDbContext context) {
        _context = context;
    }

    public IActionResult Index() {
        return View();
    }

    public JsonResult GuardarLocalidad(string Localidadid, )

}

