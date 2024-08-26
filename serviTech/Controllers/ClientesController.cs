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



      public IActionResult GuardarCliente (int? clienteID, string nombre, string apellido, int dni, string direccion, int localidadID, string email, int telefono) {
         string error = "";
         if (!String.IsNullOrEmpty(nombre) || !String.IsNullOrEmpty(apellido))  {
            if (clienteID == 0) {
                 var existeDNI = _context.Clientes.Where(d => d.Dni == dni).Count();
                 if (existeDNI == 0 ) {
                    var nuevoCliente = new Cliente {
                        Nombre = nombre,
                        Apellido = apellido,
                        Dni = dni,
                        Direccion = direccion,
                        Email = email,
                        Telefono = telefono,
                        LocalidadID = localidadID,
                        
                    
                    };
                    _context.Clientes.Add(nuevoCliente);
                    _context.SaveChanges();
                 }
                 else {
                    /* Else para editar */
                 }
            }
            else {
                error = "Ya existe un cliente con ese DNI";
            }

         }
         else {
            error = "Ingrese los datos obligatorios";
         }
         return Json (error);
      }

      public IActionResult ListaClientes(int? clienteID) {
        var listaClientes = _context.Clientes.Include(p => p.Localidades).ToList();

        /* listaClientes = _context.Clientes.OrderBy(c => c.Nombre).ToList(); */

        var mostrarClientes = listaClientes.Select(e => new VistaCliente {
            ClienteID = e.ClienteID,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            Direccion = e.Direccion,
            Email = e.Email,
            Telefono = e.Telefono,
            Dni = e.Dni,
            LocalidadID = e.LocalidadID,
            NombreLocalidad = e.Localidades.NombreLocalidad,
        });
         
        return Json(mostrarClientes);

      }







  /*   public JsonResult ListadoClientes(int? id)
    {

        var Cliente = _context.Clientes.ToList();


        if (id != null)
        {

            Cliente = Cliente.Where(t => t.ClienteID == id).ToList();
        }

        return Json(Cliente);
    } */
//      public JsonResult GuardarCliente(int ClienteID, string Nombre)
//     {
//          string resultado = "";
//          if (!String.IsNullOrEmpty(ClienteID))
//          {
//              ClienteID = ClienteID.ToUpper();

//              if (ClienteID == 0)
//              {
//                  var existeCliente = _context.Clientes.Where(t => t.Clientes == clientes).Count();
//                  if (existeCliente == 0){
//                      var Clientes = new Cliente
//                      {
//                          Clientes = Clientes
//                      };
//                      _context.Add(Clientes);
//                      _context.SaveChanges();
//                  }
//                   else
//                  {
//                      resultado = "YA EXISTE UN REGISTRO CON LA MISMA DESCRIPCIÓN";
//                  }
//              }
//              else
//              {
//                  //QUIERE DECIR QUE VAMOS A EDITAR EL REGISTRO
//                  var clienteEditar = _context.Clientes.Where(t => t.ClientesID == ClientesID).SingleOrDefault();
//                  if (clienteEditar != null)
//                  {
//                      //BUSCAMOS EN LA TABLA SI EXISTE UN REGISTRO CON EL MISMO NOMBRE PERO QUE EL ID SEA DISTINTO AL QUE ESTAMOS EDITANDO
//                      var existeCliente = _context.Clientes.Where(t => t.Nombre == nombre && t.ClientesID != ClientesID).Count();
//                      if (existeCliente == 0)
//                      {
//                          //QUIERE DECIR QUE EL ELEMENTO EXISTE Y ES CORRECTO ENTONCES CONTINUAMOS CON EL EDITAR
//                          clienteEditar.Nombre = nombre;
//                          _context.SaveChanges();
//                      }
//                      else
//                      {
//                          resultado = "YA EXISTE UN REGISTRO CON LA MISMA DESCRIPCIÓN";
//                      }
//                  }
//              }

//          }
//      }



/* public async Task<IActionResult> GuardarCliente(int? clienteId, string nombre)
    {
        if (clienteId.HasValue && !string.IsNullOrEmpty(nombre))
        {
            // Convierte el ID a mayúsculas para consistencia
            clienteId = clienteId.Value.ToString().ToUpper();

            // Verifica si el cliente ya existe por ID
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.ClientesID == clienteId);

            if (!clienteExiste)
            {
                // Inserta un nuevo cliente si no existe
                var nuevoCliente = new Cliente
                {
                    ClientesID = clienteId, // Asume que ClientesID es el campo correcto para el ID
                    Nombre = nombre
                };

                _context.Clientes.Add(nuevoCliente);
                await _context.SaveChangesAsync();
                return Json(new { mensaje = "Cliente creado exitosamente." }); // Retorna un mensaje de éxito
            }
            else
            {
                // Actualiza el cliente existente si el ID coincide
                var clienteParaActualizar = await _context.Clientes.FindAsync(clienteId);
                if (clienteParaActualizar != null)
                {
                    clienteParaActualizar.Nombre = nombre;
                    await _context.SaveChangesAsync();
                    return Json(new { mensaje = "Cliente actualizado exitosamente." }); // Retorna un mensaje de éxito
                }
                else
                {
                    // Maneja el caso en que el cliente no se encontró
                    return NotFound(new { mensaje = "Cliente no encontrado." }); // Retorna un mensaje de error
                }
            }
        }
        else
        {
            // Maneja el caso en que el ID o el nombre están vacíos
            return BadRequest(new { mensaje = "Debe proporcionar un ID y un nombre válidos." }); // Retorna un mensaje de error
        }
    } */




}

