window.onload = ListadoClientes;

function ListadoClientes()
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

}






document.addEventListener('DOMContentLoaded', function ()
{
  var elems = document.querySelectorAll('.modal');
  var instances = M.Modal.init(elems);
});

function LimpiarModal()
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


function GuardarCliente()
{
  let ClienteID = document.getElementById(ClienteID).value;
  let Apellido = document.getElementById(Apellido).value;
  let Direccion = document.getElementById(Direccion).value;
  let LocalidadID = document.getElementById(LocalidadID).value;
  let ProvinciaID = document.getElementById(ProvinciaID).value;
  let CP = document.getElementById(CP).value;
  let Email = document.getElementById(Email).value;
  let Telefono = document.getElementById(Telefono).value;
  let Dni = document.getElementById(Dni).value;
  console.log(ClienteID);
  $.ajax({
    url: '../../Cliente/GuardarListadoClientes',
    data: { 
      ClienteID: ClienteID, 
      Apellido: Apellido, 
      Direccion: Direccion, 
      LocalidadID: LocalidadID, 
      ProvinciaID: ProvinciaID,
      CP: CP,
      Email: Email,
      Telefono: Telefono,
      Dni: Dni
    },
    type: 'POST',
    dataType: 'json',
  
    success: function (resultado) {
      if (resultado != "") {
        Swal.fire(resultado);
      }
      ListadoClientes();
    },
  
    error: function (xhr, status) {
      console.log('Disculpe, existió un problema al guardar el registro');
    }
  });

}


function EliminarCliente(ClienteID)
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

  }

  Swal.fire({
    position: "top-end",
    icon: "success",
    title: "Your work has been saved",
    showConfirmButton: false,
    timer: 1500
  });  
