using Microsoft.AspNetCore.Mvc;

namespace serviTech.Controllers;

public class ClientesController : Controller
{
    private readonly ILogger<ClientesController> _context;

    public ClientesController(ILogger<ClientesController> context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    /* public IActionResult GuardarCliente() {

    } */
}