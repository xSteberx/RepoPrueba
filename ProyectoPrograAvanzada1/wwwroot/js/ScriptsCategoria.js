
function crearNuevaCategoria() {
    var formData = new FormData(document.getElementById('crearCategoriaForm'));

 

    fetch('/Categoria/tRegistrarCategoria', {
        method: 'POST',
        body: formData
    }).then(response => {
        Swal.close();

        if (!response.ok) {
            throw new Error('Hubo un error al intentar registrar la categoria.');
        }
        return response.json();
    }).then(data => {
        if (data.success) {
            Swal.fire({
                icon: 'success',
                title: 'Categoria Creada',
                text: 'Se registr\u00F3 la categoria correctamente!',
                showConfirmButton: false
            });
            setTimeout(function () {
                window.location.href = '/Categoria/ConsultarCategorias';
            }, 1500);
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error al registrar la categoria',
                text: data.message || 'La categoria que intenta registrar ya existe',
                showConfirmButton: true
            });
        }
    }).catch(error => {
        Swal.fire(
            'Error!',
            'Hubo un error al intentar registrar la categoria.',
            'error'
        );
    });
}

function consultarCategoria(element) {
    var idCategoria = element.getAttribute('data-idrolcategoria');
    fetch('/Categoria/ConsultarCategoriaesp?IdCategoria=' + idCategoria)
        .then(response => response.json())
        .then(data => {
            if (data != null) {
                document.getElementById('NombreCategoria').value = data.nombre;
                document.getElementById('IdCategoria').value = data.idCategoria;
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Error de Carga',
                    text: 'Error al cargar los datos!',
                    showConfirmButton: false
                });
                setTimeout(function () {
                    window.location.href = '/Categoria/ConsultarCategorias';
                }, 1500);
            }
        })
        .catch(error => console.error('Error al consultar el USU:', error));
}

function guardarCambiosCategoria() {
    var nombreCategoria = document.getElementById('NombreCategoria').value;
    var idCategoria = document.getElementById('IdCategoria').value;
    
    var formData = new FormData();
    formData.append('Nombre', nombreCategoria);
    formData.append('IdCategoria', idCategoria);
    console.log(idCategoria)
    fetch('/Categoria/tActualizarCategoria', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (!response.ok) {
            throw new Error('Hubo un error al intentar actualizar la categoria.');
        }
        return response.json();

    }).then(data => {
        Swal.close();

        if (data.success) {
            Swal.fire({
                icon: 'success',
                title: 'Categoria Actualizada',
                text: 'Se actualizo la categoria  correctamente!',
                showConfirmButton: false
            });
            setTimeout(function () {
                window.location.href = '/Categoria/ConsultarCategorias';
            }, 1500);
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error al actualizar la categoria',
                text: data.message || 'Hubo un error al intentar actualizar la categoria.',
                showConfirmButton: true
            });
        }
    }).catch(error => {
        Swal.close();
        Swal.fire(
            'Error!',
            'Hubo un error al intentar actualizar la categoria.',
            'error'
        );
    });
}

function eliminacategoria(link) {
    var IdCategoria = link.getAttribute('data-idcategoria');
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
            fetch('/Categoria/EliminarCategoria', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: 'IdCategoria=' + IdCategoria
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Hubo un error al intentar eliminar la categoria.');
                    }
                    return response.json();
                })
                .then(data => {
                    if (data.success) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Categoria Eliminada',
                            text: 'Se elimin\u00F3 la categoria correctamente!',
                            showConfirmButton: false
                        });
                        setTimeout(function () {
                            window.location.href = '/Categoria/ConsultarCategorias';
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
