using Microsoft.AspNetCore.Mvc;
using serviTech.Data;

namespace serviTech.Controllers;

public class AdministradorController : Controller {
    private ApplicationDbContext _context;

    public AdministradorController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() {
        return View();
    }
}