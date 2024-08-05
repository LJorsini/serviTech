using Microsoft.AspNetCore.Mvc;
using serviTech.Data;

namespace serviTech.Controllers;

public class OrdenesController : Controller {
    private ApplicationDbContext _context;

    public OrdenesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() {
        return View();
    }
}