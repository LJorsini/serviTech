window.onload = Funciona();

function Funciona() {
    console.log("Funciona")
}

function CargarLocalidad() {
    let localidadid = document.getElementById("localidadId").value;
    let nombreLocalidad = document.getElementById("nombreLocalidad").value;
    let cpLocalidad = document.getElementById("cpLocalidad").value;
    let provincia = document.getElementById("provincia").value;

    $.ajax({
        url: "../Localidades/GuardarLocalidad", 
        data: {Localidadid: localidadid, NombreLocalidad: nombreLocalidad, CpLocalidad: cpLocalidad, Provincia: provincia },
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