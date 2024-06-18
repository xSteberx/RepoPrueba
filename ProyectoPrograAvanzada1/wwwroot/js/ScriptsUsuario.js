function consultarUsuario(element) {
    var idUsuario = element.getAttribute('data-idroluser');
    fetch('/Usuario/ConsultarUsuarioesp?IdUsuario=' + idUsuario)
        .then(response => response.json())
        .then(data => {
            if (data != null) {
                document.getElementById('NombreUser').value = data.nombreUsuario;
                document.getElementById('Correo2').value = data.correo;
                document.getElementById('idUsuario').value = data.idUsuario;
                var switchCheckbox = document.getElementById('EstadoSwitch');
                switchCheckbox.checked = data.estado;

                var switchLabel = document.getElementById('EstadoLabel');
                switchLabel.textContent = data.estado ? "Activo" : "Inactivo";
                switchLabel.style.color = data.estado ? "green" : "red";

                var select = document.getElementById('IdRol2');
                select.value = data.idRol;

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
                    window.location.href = '/Usuario/ConsultarUsuarios';
                }, 1500);
            }
        })
        .catch(error => console.error('Error al consultar el USU:', error));
}



function guardarCambiosUsuario() {
    var idRol = document.getElementById("IdRol2").value;
    var idUsuario = document.getElementById("idUsuario").value;
    var Nombre = document.getElementById("NombreUser").value;
    var Correo = document.getElementById("Correo2").value;
    var Estado = document.getElementById("EstadoSwitch").checked;


    var formData = new FormData();

    formData.append('IdUsuario', idUsuario);
    formData.append('NombreUsuario', Nombre);
    formData.append('IdRol', idRol);
    formData.append('Estado', Estado);
    formData.append('Correo', Correo);

    fetch('/Usuario/tActualizarUsuario', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (!response.ok) {
            throw new Error('Hubo un error al intentar actualizar el usuario.');
        }
        return response.json();

    }).then(data => {
        Swal.close();

        if (data.success) {
            Swal.fire({
                icon: 'success',
                title: 'Usuario Actualizado',
                text: 'Se actualizo el usuario  correctamente!',
                showConfirmButton: false
            });
            setTimeout(function () {
                window.location.href = '/Usuario/ConsultarUsuarios';
            }, 1500);
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error al actualizar el usuario',
                text: data.message || 'Hubo un error al intentar actualizar el usuario.',
                showConfirmButton: true
            });
            setTimeout(function () {
                window.location.href = '/Usuario/ConsultarUsuarios';
            }, 1500);
        }
    }).catch(error => {
        Swal.close();
        Swal.fire(
            'Error!',
            'Hubo un error al intentar actualizar el usuario.',
            'error'
        );
    });
}

function eliminausuario(button) {
    var IdUsuario = button.getAttribute('data-idusuario');
    document.querySelectorAll('.eliminar-usuario').forEach(item => {
        item.addEventListener('click', function (event) {
            event.preventDefault();
            const idUsuario = this.getAttribute('data-id');
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
                    fetch('/Usuario/EliminarUsuario', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        body: 'IdUsuario=' + IdUsuario
                    })
                        .then(response => {
                            if (!response.ok) {
                                throw new Error('Hubo un error al intentar eliminar el usuario.');
                            }
                            return response.json();
                            setTimeout(function () {
                                window.location.href = '/Usuario/ConsultarUsuarios';
                            }, 1500);
                        })
                        .then(data => {
                            if (data.success) {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Usuario Eliminado',
                                    text: 'Se elimin\u00F3 el usuario correctamente!',
                                    showConfirmButton: false
                                });
                                setTimeout(function () {
                                    window.location.href = '/Usuario/ConsultarUsuarios';
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
        });
    });
}

function crearNuevoUsuario() {
    var formData = new FormData(document.getElementById('crearUsuarioForm'));

    var timerInterval;
    Swal.fire({
        title: 'Procesando...',
        timer: 3000,
        didOpen: () => {
            Swal.showLoading();
            timerInterval = setInterval(() => {
                const content = Swal.getContent();
                if (content) {
                    const b = content.querySelector('b');
                    if (b) {
                        b.textContent = Swal.getTimerLeft();
                    }
                }
            }, 1000);
        },
        willClose: () => {
            clearInterval(timerInterval);
        }
    });

    fetch('/Usuario/tRegistrarUsuario', {
        method: 'POST',
        body: formData
    }).then(response => {
        Swal.close();

        if (!response.ok) {
            throw new Error('Hubo un error al intentar registrar el usuario.');
        }
        return response.json();
    }).then(data => {
        if (data.success) {
            Swal.fire({
                icon: 'success',
                title: 'Usuario Creado',
                text: 'Se registró el usuario correctamente!',
                showConfirmButton: false
            });
            setTimeout(function () {
                window.location.href = '/Usuario/ConsultarUsuarios';
            }, 1500);
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Error al registrar el usuario',
                text: data.message || 'El correo que intenta registrar ya existe, pruebe de nuevo con uno diferente por favor',
                showConfirmButton: true
            });
        }
    }).catch(error => {
        Swal.fire({
            icon: 'error',
            title: 'Error al registrar el usuario',
            showConfirmButton: true
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.reload();
            }
        });
    });
}






