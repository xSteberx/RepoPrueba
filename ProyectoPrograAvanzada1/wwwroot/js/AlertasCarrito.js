$(document).ready(function () {
    $('.btn-agregar-carrito').click(function (e) {
        e.preventDefault();
        var form = $(this).closest('form');
        $.post(form.attr('action'), form.serialize(), function (response) {
            if (response.success) {
                Swal.fire({
                    icon: 'success',
                    title: '¡Producto agregado al carrito exitosamente!',
                    showConfirmButton: false,
                    timer: 1500
                });
                setTimeout(function () {
                    window.location.href = window.location.href;
                }, 1500);
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Error al agregar el producto al carrito',
                    text: 'Por favor, inténtalo de nuevo.',
                    confirmButtonColor: '#d33',
                    confirmButtonText: 'Cerrar'
                });
            }
        });
    });

 
    function actualizarCantidadCarrito() {
        $.ajax({
            url: '/Carrito/ObtenerCantidadCarrito',
            type: 'GET',
            success: function (data) {
                if (data.success) {
                    var cantidad = data.cantidadEnCarrito;
                    $('#carritoCantidad').text(cantidad);
                    if (cantidad > 0) {
                        $('#carritoNavItem').show();
                    } else {
                        $('#carritoNavItem').hide();
                    }
                }
            }
        });
    }

    actualizarCantidadCarrito();
});
