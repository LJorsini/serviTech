window.onload = Funciona();
window.onload = ListadoProductos();

function Funciona () {
    console.log("Funciona");
}

function ListadoProductos () {
    $.ajax({
        url: "../Productos/Listado", 
        data: {},
        type: "POST", 
        dataType: "json", 
        success: function(productos) {
            let tablaProductos = ``;
            
            $.each(productos, function(index, producto){
                let colorBoton = "";  //variable para cambiar el color del boton

                // dependiendo el stock va a generar una clase para cambiar el color del boton dependiendo la cantidad de stock del producto
                if (producto.stockActual === 0) 
                {
                    colorBoton = "red"; //stock 0
                } else if (producto.stockActual <= stockMinimo) {
                    colorBoton = "yellow" //stock por debajo del minimo
                } else {
                    colorBoton = " teal lighten-1" //stock por encima del minimo
                }
                
                tablaProductos += `
                    <tr>
                        <td>${producto.productoID}</td>
                        <td>${producto.nombre}</td>
                        <td>${producto.descripcion}</td>
                        <td>${producto.precio}</td>
                        <td>
                            <button class="btn waves-effect ${colorBoton} btn modal-trigger" data-target="modal1" type="submit" name="action" onclick="ModalAgregarStock(${producto.productoID})">AGREGAR
                            (${producto.stockActual})
                            </button>
                        </td>
                        
                        
                    </tr>
                `;
                
            });
            document.getElementById("body-tablaProductos").innerHTML = tablaProductos;
            console.log(productos);
        },
        error: function(xhr, status) {
            // Función que se ejecuta si hay un error
            console.error("Mensaje error");
        }
    });

}

function NuevoProducto () {
    let productoID = document.getElementById("productoID").value;
    let nombreProducto = document.getElementById("nombreProducto").value;
    let descripcionProducto = document.getElementById("descripcionProducto").value;
    let precio = document.getElementById("precioProducto").value;
    let stockMinimo = document.getElementById("stockMinimo").value;
    

    $.ajax({
        url: "../Productos/GuardarProducto", 
        data: {productoID: productoID, nombreProducto: nombreProducto, descripcionProducto: descripcionProducto, precio: precio, stockMinimo: stockMinimo},
        type: "POST", 
        dataType: "json", 
        success: function(response) {
            // Función que se ejecuta si la solicitud es exitosa
            console.log(response);
            Swal.fire({
                position: "center",
                icon: "success",
                title: "El Producto se guardo con exito",
                showConfirmButton: false,
                timer: 1500
              });
            LimpiarFormulario ();

        },
        error: function(xhr, status) {
            // Función que se ejecuta si hay un error
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "Disculpe, hubo un error al guardar el producto",
              });
        }
    });
}

function ModalAgregarStock (productoID) {
    $.ajax({
        url: "../Productos/ObtenerProductos", 
        data: {productoID: productoID},
        type: "POST", 
        dataType: "json", 
        success: function(response) {
            // Función que se ejecuta si la solicitud es exitosa
            console.log(response);
        },
        error: function(xhr, status) {
            // Función que se ejecuta si hay un error
            console.error("Mensaje error");
        }
    });
}

function LimpiarFormulario () {
    document.getElementById("productoID").value = 0;
    document.getElementById("nombreProducto").value = " ";
    document.getElementById("descripcionProducto").value = " ";
    document.getElementById("precioProducto").value = 0;
    document.getElementById("stockMinimo").value = 0;
}

