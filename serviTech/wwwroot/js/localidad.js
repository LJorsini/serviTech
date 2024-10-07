window.onload = Funciona();
window.onload = MostrarLocalidades();

function Funciona() {
    console.log("Funciona123")
}

function MostrarLocalidades() {
    console.log("funcionaMostrarLocalidad");
    $.ajax({
        url: "../Localidades/Lista", 
        data: {},
        type: "POST", 
        dataType: "json", 
        success: function(listaLocalidades) {
            let tabla = "";

            $.each(listaLocalidades, function (index, localidad) {
                tabla += `
                        <tr>
                            <td>${localidad.nombreLocalidad}</td>
                            <td>${localidad.cp}</td>
                            <td>${localidad.nombreProvincia}</td>
                            <td>
                                <button class="btn waves-effect waves-light btn-small" type="submit" name="action" onclick = "EditarLocalidad(${localidad.localidadID})">EDITAR
                                    <i class="material-icons left">edit</i>
                                </button>

                                <button class="btn waves-effect waves-light red accent-3 btn-small" type="submit" name="action" onclick = "ValidacionEliminar(${localidad.localidadID})">ELIMINAR
                                    <i class="material-icons left">delete</i>
                                </button>
                            </td>
                        </tr>
                `
                document.getElementById("body-tLocalidad").innerHTML = tabla;
            })


           
        },
        error: function(xhr, status) {
            // Función que se ejecuta si hay un error
            console.error("Mensaje error");
        }
    });
}

function CargarLocalidad() {

    let localidadID = document.getElementById("localidadId").value;
    let nombreLocalidad = document.getElementById("nombreLocalidad").value;
    let cpLocalidad = document.getElementById("cpLocalidad").value;
    let provinciaID = document.getElementById("ProvinciaID").value;

    $.ajax({
        url: "../Localidades/GuardarLocalidad", 
        data: {localidadID: localidadID, provinciaID: provinciaID, nombreLocalidad: nombreLocalidad, cp: cpLocalidad},
        type: "POST", 
        dataType: "json", 
        success: function(resultado) {
            MostrarLocalidades();
            
            alert(resultado);
        },
        error: function(xhr, status) {
            
            console.error("Mensaje error");
        }
    });
}

function LimpiarModal () {
    document.getElementById("localidadId").value = 0;
    document.getElementById("nombreLocalidad").value = "";
    document.getElementById("cpLocalidad").value = "";
    document.getElementById("ProvinciaID").value = 0;
}

function ValidacionEliminar (localidadID) {
    let confirmar = confirm("DeseaEliminar?");
    if (confirmar == true) {
        EliminarLocalidad(localidadID)
    }
}

function EliminarLocalidad (localidadID) {
    $.ajax({
        url: "../Localidades/Eliminar", 
        data: {localidadID: localidadID},
        type: "POST", 
        dataType: "json", 
        success: function(localidadEliminada) {
            MostrarLocalidades()
            
        },
        error: function(xhr, status) {
            // Función que se ejecuta si hay un error
            console.error("Mensaje error");
        }
    });
}