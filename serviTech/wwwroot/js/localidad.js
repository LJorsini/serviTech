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
                                <button class="btn waves-effect waves-light" type="submit" name="action" onclick = "EditarLocalidad(${localidad.localidadID})">EDITAR
                                    <i class="material-icons left">edit</i>
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
    console.log("funciona")
    /* LimpiarModal (); */
    let localidadID = document.getElementById("localidadId").value;
    let nombreLocalidad = document.getElementById("nombreLocalidad").value;
    let cpLocalidad = document.getElementById("cpLocalidad").value;
    let provinciaID = document.getElementById("ProvinciaID").value;

    $.ajax({
        url: "../Localidades/GuardarLocalidad", 
        data: {localidadID: localidadID, provinciaID: provinciaID, nombreLocalidad: nombreLocalidad, cp: cpLocalidad},
        type: "POST", 
        dataType: "json", 
        success: function(response) {
            LimpiarModal ();
            console.log(response);
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