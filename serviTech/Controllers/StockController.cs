using Microsoft.AspNetCore.Mvc;
using serviTech.Data;

namespace serviTech.Controllers;

public class StockController : Controller {
    private ApplicationDbContext _context;

    public StockController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() {
        return View();
    }
}