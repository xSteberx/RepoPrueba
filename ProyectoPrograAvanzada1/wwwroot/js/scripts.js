function cambiacontrauser() {
    const form = document.querySelector('form');

    const contrasennaTemporal = form.querySelector('#ContrasennaNueva').value;
    const nuevaContrasenna = form.querySelector('#ContrasennaNueva2').value;
    const contrasennaPattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{6,20}$/;

    if (!contrasennaTemporal || !nuevaContrasenna) {
        Swal.fire({
            html: `
            <div class="container">
                <lord-icon
                    src="https://cdn.lordicon.com/akqsdstj.json"
                    trigger="hover"
                    style="width: 250px; height: 250px;">
                </lord-icon>
            </div>

            <h2>&#33;Campos Vac&#237;os!</h2>
            <p>Por favor completa todos los campos.</p>
            `,
            showConfirmButton: true,
            timer: 2000
        });
    } else if (!contrasennaPattern.test(nuevaContrasenna)) {
        Swal.fire({
            icon: 'error',
            title: '\u00A1La nueva contrase\u00F1a no coincide con el formato solicitado!',
            showConfirmButton: false,
            timer: 2000
        });
    } else if (contrasennaTemporal !== nuevaContrasenna) {
        Swal.fire({
            icon: 'error',
            title: 'Las contrase\u00F1as no coinciden',
            text: 'Por favor, aseg\u00FArate de que las contrase\u00F1as coincidan',
            showConfirmButton: false,
            timer: 2000
        });
    } else {
        fetch('/Home/CambiarContraUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: `Contrasenna=${encodeURIComponent(nuevaContrasenna)}`
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error al actualizar la contrase\u00F1a');
                }
                return response.json();
            })
            .then(data => {
                if (data.success) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Contrase\u00F1a Cambiada',
                        text: 'Cambio realizado exitosamente!',
                        showConfirmButton: false
                    });
                    setTimeout(function () {
                        window.location.href = '/Home/PantallaInicio';
                    }, 1500);
                } else {
                    throw new Error(data.message || 'Error al actualizar la contrase\u00F1a');
                }
            })
            .catch(error => {
                Swal.fire({
                    icon: 'error',
                    title: 'Error al Cambiar',
                    text: 'Ocurri\u00F3 un error al intentar el cambio, por favor intenta de nuevo',
                    confirmButtonColor: '#d33',
                    confirmButtonText: 'Cerrar'
                });
            });
    }
}

function eliminausuarios(button) {
    var IdUsuario = button.getAttribute('data-idusuario');
    document.querySelectorAll('.eliminar-usuario').forEach(item => {
        item.addEventListener('click', function (event) {
            event.preventDefault();
            const idUsuario = this.getAttribute('data-id');
            Swal.fire({
                title: '¿Estás seguro?',
                text: 'Esta acción no se puede revertir',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sí, eliminarlo!',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    fetch('/Usuario/EliminarUsuario', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        body: `IdUsuario=${IdUsuario}`
                    })
                        .then(response => {
                            if (!response.ok) {
                                throw new Error('Hubo un error al intentar eliminar el usuario.');
                            }
                            return response.json();
                        })
                        .then(data => {
                            if (data.success) {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Usuario Eliminado',
                                    text: 'Se elimino el usuario correctamente!',
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