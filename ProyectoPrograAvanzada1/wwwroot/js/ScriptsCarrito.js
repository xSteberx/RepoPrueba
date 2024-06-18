function decrececantidad(button) {
    var input = button.parentNode.parentNode.querySelector('.cantidad');
    var idProducto = button.getAttribute('data-idproducto');
    var newValue = parseInt(input.value) - 1;
    if (newValue < 1) {
        Swal.fire({
            title: '&iquest;Quieres remover el producto del carrito?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'S&Iacute, quitar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                fetch('/Carrito/RemueveProducto', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    },
                    body: `IdProducto=${idProducto}`
                }).then(response => {
                    if (response.ok) {
                        return response.json();
                    } else {
                        throw new Error('Error al remover el producto');
                    }
                })
                    .then(data => {
                      
                        if (data.success == true) {
                            
                            actualizaTotal();
                                window.location.href = '/Home/PantallaInicio'; 
                        } else {
                            throw new Error('Error al remover el producto');
                        }
                    })

                    .catch(error => {
                        console.error('Error al remover el producto:', error); 
                    });



            }
        });
    } else {
        input.value = newValue;
        actualizasubtotal(button);
        actualizaTotal();
    }
}

function actualizasubtotal(button) {
    var row = button.closest('tr');
    var input = row.querySelector('.cantidad');
    var subtotalElement = row.querySelector('.subtotal');

    var cantidad = parseInt(input.value);
    var precio = parseFloat(row.querySelector('.precio').innerText.replace(/[^\d.]/g, ''));

    var subtotal = cantidad * precio;
    subtotalElement.innerText = formatCurrency(subtotal);
}

function actualizaTotal() {
    var totalElement = document.querySelector('.total');

    var total = 0;
    var subtotales = document.querySelectorAll('.subtotal');
    subtotales.forEach(function (subtotalElement) {
        var subtotalText = subtotalElement.innerText.replace(/[^\d.]/g, '');
        total += parseFloat(subtotalText);
    });

    totalElement.innerText = formatCurrency(total);
}

function incrementacantidad(button) {
    var row = button.closest('tr');
    var cantidadInput = row.querySelector('.cantidad');
    var subtotalElement = row.querySelector('.subtotal');
    var totalElement = document.querySelector('.total');

    var cantidad = parseInt(cantidadInput.value);
    var precio = parseFloat(row.querySelector('.precio').innerText.replace(/[^\d,]/g, '').replace(',', '.'));

    cantidad++;

    cantidadInput.value = cantidad;

    var subtotal = cantidad * precio;
    subtotalElement.innerText = formatCurrency(subtotal);

    var total = 0;
    var subtotales = document.querySelectorAll('.subtotal');
    subtotales.forEach(function (subtotalElement) {
        total += parseFloat(subtotalElement.innerText.replace(/[^\d.]/g, '').replace('.', '').replace(',', '.'));
    });

    totalElement.innerText = formatCurrency(total);
}

function formatCurrency(amount) {
    var formattedAmount = amount.toFixed(0);

    formattedAmount = formattedAmount.replace(/\d(?=(\d{3})+\.)/g, '$&,');
    return '₡ ' + formattedAmount;
}
