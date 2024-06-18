function crearNuevoProducto() {
    var formData = new FormData(document.getElementById('crearProductoForm'));
    fetch('/Producto/tRegistrarProducto', {
        method: 'POST',
        body: formData
    }).then(response => {
        Swal.close();

        if (!response.ok) {
            throw new Error('Hubo un error al intentar registrar el producto.');
        }
        return response.json();
    }).then(data => {
        if (data.success) {
            Swal.fire({
                icon: 'success',
                title: 'Producto Creado',
                text: 'Se registr\u00F3 el producto correctamente!',
                showConfirmButton: false
            });
            setTimeout(function () {
                window.location.href = '/Producto/ConsultarProductos';
            }, 1500);
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error al registrar el producto',
                text: data.message || 'El producto que intenta registrar ya existe, pruebe de nuevo con uno diferente por favor',
                showConfirmButton: true
            });
        }
    }).catch(error => {
        Swal.fire(
            'Error!',
            'Hubo un error al intentar registrar el producto.',
            'error'
        );
    });
}

function mostrarImagenSeleccionada(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            document.getElementById('ImagenProductoPreview').src = e.target.result;
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function consultarProducto(element) {
    var idProducto = element.getAttribute('data-idproducto');
    fetch('/Producto/ConsultarProductoesp?IdProducto=' + idProducto)
        .then(response => response.json())
        .then(data => {
            if (data != null) {
                document.getElementById('NombreProducto').value = data.nombre;
                document.getElementById('IdProducto').value = data.idProducto;
                document.getElementById('IdCategoriaProducto').value = data.idCategoria;
                document.getElementById('PrecioProducto').value = data.precio;
                document.getElementById('StockProds').value = data.stock;
                var imagenPreview = document.getElementById('ImagenProductoPreview');
                imagenPreview.src = data.imagen;

                var switchCheckbox = document.getElementById('EstadoSwitch');
                switchCheckbox.checked = data.estado;

                var switchLabel = document.getElementById('EstadoLabel');
                switchLabel.textContent = data.estado ? "Activo" : "Inactivo";
                switchLabel.style.color = data.estado ? "green" : "red";

                switchCheckbox.addEventListener('change', function () {
                    switchLabel.textContent = this.checked ? "Activo" : "Inactivo";
                    switchLabel.style.color = this.checked ? "green" : "red";
                });
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Error de Carga',
                    text: 'Error al cargar los datos!',
                    showConfirmButton: false
                });
                setTimeout(function () {
                    window.location.href = '/Producto/ConsultarProductos';
                }, 1500);
            }
        })
        .catch(error => console.error('Error al consultar el USU:', error));
}

document.getElementById('ImagenProductoInput').addEventListener('change', function () {
    mostrarImagenSeleccionada(this);
});

function guardarCambiosProducto() {
    var nombreProducto = document.getElementById('NombreProducto').value;
    var idProducto = document.getElementById('IdProducto').value;
    var idCategoria = document.getElementById('IdCategoriaProducto').value;
    var precio = document.getElementById('PrecioProducto').value;
    var estado = document.getElementById('EstadoSwitch').checked;
    var imagenInput = document.getElementById('ImagenProductoInput');
    var stockprods = document.getElementById('StockProds').value;
    var imagen = imagenInput.files[0];
   
    var formData = new FormData();

    formData.append('IdProducto', idProducto);
    formData.append('IdCategoria', idCategoria);
    formData.append('Nombre', nombreProducto);
    formData.append('Estado', estado);
    formData.append('Stock', stockprods); 
    formData.append('ImagenProd', imagen); 
    var nombreImagen = imagenInput.value.split('\\').pop(); 
    formData.append('NombreImagen', nombreImagen); 

    formData.append('Precio', precio);
    
    fetch('/Producto/tActualizarProducto', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (!response.ok) {
            throw new Error('Hubo un error al intentar actualizar el producto.');
        }
        return response.json();

    }).then(data => {
        
        Swal.close();

        if (data.success) {
            Swal.fire({
                icon: 'success',
                title: 'Producto Actualizado',
                text: 'Se actualiz\u00F3 el producto correctamente!',
                showConfirmButton: false
            });
            setTimeout(function () {
                window.location.href = '/Producto/ConsultarProductos';
            }, 1500);
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error al actualizar el producto',
                text: data.message || 'Hubo un error al intentar actualizar el producto.',
                showConfirmButton: true
            });
        }
    }).catch(error => {
        Swal.close();
        Swal.fire(
            'Error!',
            'Hubo un error al intentar actualizar el producto.',
            'error'
        );
    });
}


function eliminaproducto(link) {
    var IdProducto = link.getAttribute('data-idproducto');
    Swal.fire({
        title: '\u00BFEst\u00E1s seguro?',
        text: 'Esta acci\u00F3n no se puede revertir',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'S\xED, eliminarlo!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch('/Producto/EliminarProducto', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: 'IdProducto=' + IdProducto
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Hubo un error al intentar eliminar el producto.');
                    }
                    return response.json();
                })
                .then(data => {
                    if (data.success) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Producto Eliminado',
                            text: 'Se elimin\u00F3 el producto correctamente!',
                            showConfirmButton: false
                        });
                        setTimeout(function () {
                            window.location.href = '/Producto/ConsultarProductos';
                        }, 1500);
                    }
                })
                .catch(error => {
                    Swal.fire(
                        'Error!',
                        error.message,
                        'error'
                    );
                });
        }
    });
}
