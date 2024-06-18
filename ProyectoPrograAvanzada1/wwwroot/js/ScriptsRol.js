
function crearNuevoRol() {
  
    var formData = new FormData(document.getElementById('crearRolForm'));

    fetch('/Rol/tRegistrarRol', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (!response.ok) {
            throw new Error('Hubo un error al intentar registrar el rol.');
        }
        return response.json();

    }).then(data => {
        Swal.close();

        if (data.success) {
            Swal.fire({
                icon: 'success',
                title: 'Rol Creado',
                text: 'Se registr\u00F3 el rol  correctamente!',
                showConfirmButton: false
            });
            setTimeout(function () {
                window.location.href = '/Rol/ConsultarRoles';
            }, 1500);
        }else {
            Swal.fire({
                icon: 'error',
                title: 'Error al registrar el rol',
                text: data.message || 'Hubo un error al intentar registrar el rol.',
                showConfirmButton: true
            });
        }
    }).catch(error => {
        Swal.close();
        Swal.fire(
            'Error!',
            'Hubo un error al intentar registrar el rol.',
            'error'
        );
    });
}
function consultarRol(element) {
    var idRol = element.getAttribute('data-idrol');
    fetch('/Rol/ConsultarRolesp?IdRol=' + idRol) 
        .then(response => response.json())
        .then(data => {
            if (data != null) { 
                document.getElementById('NombreRol').value = data.nombre;
                document.getElementById('IdRol').value = data.idRol;
            } else {
               
            }
        })
        .catch(error => console.error('Error al consultar el rol:', error));
}

function guardarCambiosRol(){
    var nombreRol = document.getElementById("NombreRol").value;
    var idRol = document.getElementById("IdRol").value;

    var formData = new FormData();

    formData.append('Nombre', nombreRol);
    formData.append('IdRol', idRol);

    fetch('/Rol/tActualizaRol', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (!response.ok) {
            throw new Error('Hubo un error al intentar actualizar el rol.');
        }
        return response.json();

    }).then(data => {
        Swal.close();

        if (data.success) {
            Swal.fire({
                icon: 'success',
                title: 'Rol Actualizado',
                text: 'Se actualizo el rol  correctamente!',
                showConfirmButton: false
            });
            setTimeout(function () {
                window.location.href = '/Rol/ConsultarRoles';
            }, 1500);
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error al actualizar el rol',
                text: data.message || 'Hubo un error al intentar actualizar el rol.',
                showConfirmButton: true
            });
        }
    }).catch(error => {
        Swal.close();
        Swal.fire(
            'Error!',
            'Hubo un error al intentar actualizar el rol.',
            'error'
        );
    });
}

function eliminarol(link) {
    var IdRol = link.getAttribute('data-idrol');
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
            fetch('/Rol/EliminarRol', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: 'IdRol=' + IdRol
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Hubo un error al intentar eliminar el rol.');
                    }
                    return response.json();
                })
                .then(data => {
                    if (data.success) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Rol Eliminado',
                            text: 'Se elimin\u00F3 el rol correctamente!',
                            showConfirmButton: false
                        });
                        setTimeout(function () {
                            window.location.href = '/Rol/ConsultarRoles';
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
