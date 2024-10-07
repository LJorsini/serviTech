window.onload = MostrarCliente();

function MostrarCliente () {
  let tablaClientes = ``;

  $.ajax({
    url: "../Clientes/ListaClientes", 
    data: {},
    type: "POST", 
    dataType: "json", 
    success: function(listaClientes) {
        $.each(listaClientes, function (index, cliente){
          tablaClientes += `
              <tr>
                            <td>${cliente.nombreCompleto}</td>
                            <td>${cliente.telefono}</td>
                            <td>${cliente.nombreLocalidad}</td>
                            <td>
                                <button class="btn waves-effect waves-light" type="submit" name="action" onclick = "EditarCliente(${cliente.clienteID})">EDITAR
                                    <i class="material-icons left">edit</i>
                                </button>

                                <button class="btn waves-effect waves-light red accent-3" type="submit" name="action" onclick = "ValidacionEliminar(${cliente.clienteID})">ELIMINAR
                                    <i class="material-icons left">delete</i>
                                </button>
                            </td>
                        </tr>
                  `
        });

        document.getElementById("tabla-cliente").innerHTML = tablaClientes;
        
        
    },
    error: function(xhr, status) {
        // Función que se ejecuta si hay un error
        console.error("Mensaje error");
    }
});
}

function NuevoCliente() {
  let clienteID = document.getElementById("clienteId").value;
  let nombreCompleto = document.getElementById("nombreCompleto").value;
  let dni = document.getElementById("dni").value;
  let direccion = document.getElementById("direccion").value;
  let localidadID = document.getElementById("LocalidadID").value;
  let email = document.getElementById("email").value;
  let telefono = document.getElementById("telefono").value;

  
  
  $.ajax({
    url: "../../Clientes/GuardarCliente",
    data: {clienteID: clienteID,nombreCompleto: nombreCompleto, dni :dni, direccion: direccion, localidadID: localidadID, email: email, telefono: telefono},
    type: "POST",
    dataType: "json",

    success: function (resultado) {
      console.log(resultado)
      $('#formCliente')[0].reset();
      MostrarCliente ()
      Swal.fire({
        position: "center",
        icon: "success",
        title: "¡Cliente guardado!",
        showConfirmButton: false,
        timer: 1500
      });
      
    },

    error: function (xhr, status) {
      console.log("Disculpe, existió un problema al guardar el registro");
    },
  });
}

function ValidacionEliminar(clienteID) {
  Swal.fire({
    title: "¿Desea eliminar a el cliente?",
    showDenyButton: true,
    showCancelButton: false,
    confirmButtonText: "Eliminar",
    denyButtonText: `Cancelar`
  }).then((result) => {
    
    if (result.isConfirmed) {
      EliminarCliente (clienteID);
      
    } else if (result.isDenied) {
      Swal.fire("No se elimino el cliente", "", "info");
    }
  });
}

function EliminarCliente(clienteID) {
  $.ajax({
      url: '../../Clientes/EliminarCliente',
      data: { clienteID: clienteID },
      type: 'POST',
      dataType: 'json',
      success: function (EliminarCliente) {
         Swal.fire("¡Cliente Eliminado!", "", "success");
         MostrarCliente ();
      },
      error: function (xhr, status) {
          console.log('Problemas al eliminar el cliente');
      }
  });
}


function convertirMayusculas(elemento) {
  elemento.value = elemento.value.toUpperCase();
}




