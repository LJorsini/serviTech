 using Microsoft.AspNetCore.Mvc;
using serviTech.Data;

namespace serviTech.Controllers;

public class PresupuestosController : Controller {
    private ApplicationDbContext _context;

    public PresupuestosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() {
        return View();
    }
}

/* public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _rolManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> rolManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _rolManager = rolManager;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        //BUSCAR EL ID DEL USUARIO LOGUEADO
        var usuarioLogueadoID = _userManager.GetUserId(HttpContext.User);
        //OBJETO PARA PASARLO A VISTA PARA MOSTRAR QUE FUNCIONA
        ViewBag.UsuarioID = usuarioLogueadoID;

        var tipoEjercicios = _context.TipoEjercicios.ToList();
        ViewBag.TipoEjercicioID = new SelectList(tipoEjercicios.OrderBy(c => c.Descripcion), "TipoEjercicioID", "Descripcion");
        
        await InicializarPermisosUsuario();
        
        return View();
    } */


    