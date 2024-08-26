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
                            <td>${cliente.nombre}</td>
                            <td>${cliente.apellido}</td>
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


function LimpiarModal() {
  document.getElementById("clienteId").value;
  document.getElementById("nombre").value;
  document.getElementById("apellido").value;
  document.getElementById("dni").value;
  document.getElementById("direccion").value;
  document.getElementById("LocalidadID").value;
  document.getElementById("email").value;
  document.getElementById("telefono").value;
}



