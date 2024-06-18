/*
 * Código de JavaScript para realizar la búsqueda que se solicita en el requerimiento #5 del proyecto, es por medio de un input.
 *
 * Ahora, dicho código funciona gracias a los dos valores que sirven como ID -
 * para que el código de búsqueda pueda funcionar correctamente, los cuales son: -
 * myInput (el cual se encuentra en el input de la búsqueda) y myDIV (estos son para los elementos -
 * que están contenidos en Div y que tienen estilos de Bootstrap).
 */
$(document).ready(function () {
    $('#myInput').on('input', function () {
        var filtro = $(this).val().toLowerCase();
        $('#productos-container .card').each(function () {
            var textoProducto = $(this).text().toLowerCase();
            $(this).toggle(textoProducto.indexOf(filtro) > -1);
        });
    });
});
