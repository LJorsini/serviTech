/* window.onload = ListadoClientes; */
window.onload = Funciona();

function Funciona() {
  console.log("Funciona");
}

/* function ListadoClientes()
{

  $.ajax({
    url: '../../Cliente/ListadoClientes',
    data: {},
    type: 'POST',
    dataType: 'json',
    success: function (Clientes)
    {
      $("#modal1").modal("hide");
      LimpiarModal();

      let contenidoTabla = ``;

      $.each(Clientes, function (index, Clientes)
      {

        contenidoTabla += `
                 <tr>
                    <td>${Clientes.nombre}</td>
                    <td>${Clientes.apellido}</td>
                    <td>${Clientes.direccion}</td>
                    <td>${Clientes.localidadID}</td>
                    <td>${Clientes.cp}</td>
                    <td>${Clientes.email}</td>
                    <td>${Clientes.telefono}</td>
                    <td>${Clientes.dni}</td>
                    <td>${Clientes.reparaciones}</td>
                    <td class="text-center">
                    <button type="button" class="btn btn-success btn-sm" onclick="AbrirBotonEditar(${Clientes.ClientesID})">
                    <i class="fa-solid fa-marker"></i>
                    </button>
                    </td>
                    <td class="text-center">
                    <button type="button" class="btn btn-danger btn-sm" onclick="EliminarCliente(${Clientes.ClientesID})">
                    <i class="fa-solid fa-trash"></i>
                    </button>
                 </tr>


              `;
      });


      document.getElementById("tbody-cliente").innerHTML = contenidoTabla;

    },


    error: function (xhr, status)
    {
      console.log('Disculpe, existió un problema al cargar el listado');
    }

  });

} */

// document.addEventListener('DOMContentLoaded', function ()
// {
// document.addEventListener('DOMContentLoaded', function() {
//   var elems = document.querySelectorAll('.modal');
//   var instances = M.Modal.init(elems);
// });

/* function LimpiarModal()
{
  document.getElementById("ClienteID").value = 0;
  document.getElementById("Nombre").value = "";
  document.getElementById("Apellido").value = "";
  document.getElementById("Direccion").value = "";
  document.getElementById("LocalidadID").value = 0;
  document.getElementById("ProvinciaID").value = 0;
  document.getElementById("CP").value = 0;
  document.getElementById("Email").value = "";
  document.getElementById("Telefono").value = 0;
  document.getElementById("Dni").value = 0;

}

function NuevoCliente()
{
  $("#modal1").text("Agregar Cliente");
}

function AbrirBotonEditar(ClienteID)
{
  $.ajax({
    url: '../../Cliente/ListadoClientes',
    data: { id: ClienteID },
    type: 'POST',
    dataType: 'json',
    success: function (Clientes)
    {
      let Cliente = Cliente[0];
      document.getElementById("ClienteID").value = ClienteID;
      $("#modal1").text("Editar Cliente");
      document.getElementById("Nombre").value = Clientes.ClienteID;
      $("#modal1").modal("show");
    },

    error: function (xhr, status)
    {
      console.log('Disculpe, existió un problema al cargar el listado');
    }

  });


}
 */

function NuevoCliente() {
  let clienteID = document.getElementById("clienteId").value;
  let nombre = document.getElementById("nombre").value;
  let apellido = document.getElementById("apellido").value;
  let dni = document.getElementById("dni").value;
  let direccion = document.getElementById("direccion").value;
  let localidadID = document.getElementById("LocalidadID").value;
  let email = document.getElementById("email").value;
  let telefono = document.getElementById("telefono").value;
  
  $.ajax({
    url: "../../Clientes/GuardarCliente",
    data: {clienteID: clienteID,nombre: nombre, apellido:apellido, dni :dni, direccion: direccion, localidadID: localidadID, email: email, telefono: telefono},
    type: "POST",
    dataType: "json",

    success: function (resultado) {
      if (resultado != "") {
        
      }
      
    },

    error: function (xhr, status) {
      console.log("Disculpe, existió un problema al guardar el registro");
    },
  });
}



/* function EliminarCliente(ClienteID)
  {
    $.ajax({
      url: '../../Cliente/EliminarListadosClientes',
      data: { ClienteID: ClienteID },
      type: 'POST',
      dataType: 'json',

      success: function (resultado)
      {

        if (!resultado)
        {
          Swal.fire("No se puede eliminar");
        }
        ListadoClientes();
      },

      error: function (xhr, status)
      {
        console.log('Disculpe, existió un problema al eliminar el registro');
      }
    });

  }*/
