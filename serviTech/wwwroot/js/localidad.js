window.onload = Funciona();

function Funciona() {
    console.log("Funciona12")
}

function CargarLocalidad() {
    console.log("funciona")
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
            
            console.log(response);
        },
        error: function(xhr, status) {
            
            console.error("Mensaje error");
        }
    });
}