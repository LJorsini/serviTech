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
                    } else if (producto.stockActual <= producto.stockMinimo) {
                        colorBoton = "amber darken-3" //stock por debajo del minimo
                    } else {
                        colorBoton = "teal lighten-1" //stock por encima del minimo
                    }
                    console.log(stockMinimo);
                tablaProductos += `
                    <tr>
                        <td>${producto.productoID}</td>
                        <td>${producto.nombre}</td>
                        <td>${producto.descripcion}</td>
                        <td>${producto.precio}</td>
                        <td>${producto.stockActual}</td>
                        <td>
                            <button class="btn waves-effect ${colorBoton} btn modal-trigger" data-target="agregarStock" type="submit" name="action" onclick="ModalAgregarStock(${producto.productoID})">AGREGAR
                            
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
              ListadoProductos ();
            

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
        url: "../Productos/Listado", 
        data: {productoID: productoID},
        type: "POST", 
        dataType: "json", 
        success: function(productos) {
            let producto = productos[0];

            document.getElementById("productoID").value = productoID;
            /* document.getElementById("producto").value = producto.nombre; */
            document.getElementById("producto").innerHTML = "Producto: " + producto.nombre;
            document.getElementById("parrafoStockActual").innerHTML = "Stock actual: " + producto.stockActual;
            document.getElementById("stockMinimoModificar").value = producto.stockMinimo;

            console.log(producto.nombre);
            console.log(producto.stockMinimo);
            console.log(productos);

            ListadoProductos ();
            /* console.log(producto); */
        },
        error: function(xhr, status) {
            
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

function convertirMayusculas(texto) {
    texto.value = texto.value.toUpperCase();
  }

  function MovimientoStock () {
    let productoMovimientoID = document.getElementById("productoID").value;
    let tipoMovimiento = document.getElementById("tipoMovimiento").value;
    let cantidad = document.getElementById("cantidad").value;
    let stockMinimo = document.getElementById("stockMinimoModificar").value;
    let fechaMovimiento = document.getElementById("fechaMovimiento").value;
    let observaciones = document.getElementById("observaciones").value;


    $.ajax({
        url: "../Productos/MovimientoStock", 
        data: {productoMovimientoID: productoMovimientoID, tipoMovimiento: tipoMovimiento, cantidad:cantidad, stockMinimo:stockMinimo, fechaMovimiento: fechaMovimiento, observaciones:observaciones},
        type: "POST", 
        dataType: "json", 
        success: function(productos) {
            

            

            
            
        },
        error: function(xhr, status) {
            
            console.error("Mensaje error");
        }
    });


  }

