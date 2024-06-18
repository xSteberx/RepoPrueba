
function cambiacontrasenna() {
    event.preventDefault();
    var formData = new FormData(document.getElementById('cambiacontrasenna'));
    var contrasennaNueva = formData.get('Contrasenna');

    if (contrasennaNueva.trim() == '') {
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


    } else if (validaContrasenna(contrasennaNueva)) {
        fetch('/Home/CambiarContrasenna', {
            method: 'POST',
            body: formData
        }).then(response => {
            if (!response.ok) {
                throw new Error('Hubo un error al intentar cambiar la contrase\u00F1a.');
            }
            return response.json();

        }).then(data => {
            Swal.close();

            if (data.success) {
                Swal.fire({
                    icon: 'success',
                    title: 'Contrase\u00F1a cambiada',
                    text: 'Se cambio la contrase\u00F1a  correctamente!',
                    showConfirmButton: false
                });
                setTimeout(function () {
                    window.location.href = '/Home/IniciarSesion';
                }, 1500);
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Error al cambiar la Contrase\u00F1a',
                    text: data.message || 'Hubo un error al intentar cambiar la Contrase\u00F1a.',
                    showConfirmButton: true
                });
            }
        }).catch(error => {
            Swal.close();
            Swal.fire(
                'Error!',
                'Hubo un error al intentar cambiar  la Contrase\u00F1a.',
                'error'
            );
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'La contrase\u00F1a no cumple con los requisitos. Por favor, aseg\u00FArate de cumplir los requisitos.'
        });
    }

}



function recuperacontrasenna() {
    event.preventDefault();
    var formData = new FormData(document.getElementById('recuperacontrasenna'));
    var correo = formData.get('Correo');

    if (!correo.trim() == '') {

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
        fetch('/Home/RecuperarContrasenna', {
            method: 'POST',
            body: formData
        }).then(response => {
            if (!response.ok) {
                throw new Error('Hubo un error al intentar recuperar la contrase\u00F1a.');
            }
            return response.json();

        }).then(data => {
            Swal.close();

            if (data.success) {
                Swal.fire({
                    icon: 'success',
                    title: 'Correo Enviado',
                    text: 'Se le ha enviado un correo con una contrase\u00F1a temporal!',
                    showConfirmButton: false
                });
                setTimeout(function () {
                    window.location.href = '/Home/IniciarSesion';
                }, 2100);
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Error al recuperar la Contrase\u00F1a',
                    text: data.message || 'Hubo un error al intentar recuperar la Contrase\u00F1a.',
                    showConfirmButton: true
                });
            }
        }).catch(error => {
            Swal.close();
            Swal.fire(
                'Error!',
                'Hubo un error al intentar recuperar  la Contrase\u00F1a.',
                'error'
            );
        });
    } else {
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

    }

}
function validaContrasenna(contrasenna) {
   
    var tieneNumero = /[0-9]/.test(contrasenna);
    var tieneLetraMinuscula = /[a-z]/.test(contrasenna);
    var tieneLetraMayuscula = /[A-Z]/.test(contrasenna);
    var tieneCaracterEspecial = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(contrasenna);
    var longitudValida = contrasenna.length >= 6 && contrasenna.length <= 20;


    if (tieneNumero && tieneLetraMinuscula && tieneLetraMayuscula && tieneCaracterEspecial && longitudValida) {
        return true;
    } else {
        return false; 
    }
}
