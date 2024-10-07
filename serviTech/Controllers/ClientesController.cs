using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc.Rendering;
using serviTech.Data;
using serviTech.Models;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;


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
        var localidades = _context.Localidades.ToList();

        localidades.Add(new Localidad {LocalidadID = 0, NombreLocalidad = "[SELECCIONE...]"});

        ViewBag.LocalidadID = new SelectList(localidades, "LocalidadID", "NombreLocalidad");

        var provincias = _context.Provincias.ToList();
        var buscarProvincias = provincias.ToList();

        provincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[SELECCIONE...]" });
        buscarProvincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[Todas las Provincias]" });

        ViewBag.ProvinciaID = new SelectList(provincias, "ProvinciaID", "NombreProvincia");
        ViewBag.buscarProvincias = new SelectList(buscarProvincias, "ProvinciaID", "NombreProvincia");

        return View();

    }

    public JsonResult GuardarCliente(int clienteID, string nombreCompleto,int dni, string direccion, int localidadID, string email, int telefono)
    {
        string resultado = "";
        if (clienteID == 0)
        {
            nombreCompleto = nombreCompleto.ToUpper();
            direccion = direccion.ToUpper();
            email = email.ToUpper();
           
                var Cliente = new Cliente
                {
                    ClienteID = clienteID,
                    NombreCompleto = nombreCompleto,
                    Dni = dni,
                    Direccion = direccion,
                    LocalidadID = localidadID,
                    Email = email,
                    Telefono = telefono,
                };
                _context.Add(Cliente);
                _context.SaveChanges();

                resultado = "El cliente se guardo correctamente";
            
        }
        else
        {
            var editarCliente = _context.Clientes.Where(e => e.ClienteID == clienteID).SingleOrDefault();
            if (editarCliente != null)
            {
                editarCliente.NombreCompleto = nombreCompleto;
                editarCliente.Dni = dni;
                editarCliente.Direccion = direccion;
                editarCliente.LocalidadID = localidadID;
                editarCliente.Email = email;
                editarCliente.Telefono = telefono;

                _context.SaveChanges();

                resultado = "El cliente se actualizó correctamente";
            }
        }
        return Json(resultado);
    }

        public JsonResult EliminarCliente(int ClienteID)
    {
        var cliente = _context.Clientes.Find(ClienteID);
        _context.Remove(cliente);
        _context.SaveChanges();

        return Json(true);
    }
      public IActionResult ListaClientes(int? clienteID) {
        var listaClientes = _context.Clientes.Include(p => p.Localidades).ToList();

        /* listaClientes = _context.Clientes.OrderBy(c => c.Nombre).ToList(); */

        var mostrarClientes = listaClientes.Select(e => new VistaCliente {
            ClienteID = e.ClienteID,
            NombreCompleto = e.NombreCompleto,
            Direccion = e.Direccion,
            Email = e.Email,
            Telefono = e.Telefono,
            Dni = e.Dni,
            LocalidadID = e.LocalidadID,
            NombreLocalidad = e.Localidades.NombreLocalidad,
        });
         
        return Json(mostrarClientes);

      }


    




}

