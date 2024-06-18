$(document).ready(function () {
    initializeDataTables();
});

function initializeDataTables() {
    $('#tablaproductos').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-ES.json'
        },
        bInfo: false,
        bLengthChange: false,
        columnDefs: [
            { type: 'string', targets: [0, 1, 2,3,4,5,6] }
        ]
    });

    $('#tablacategorias').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-ES.json'
        },
        bInfo: false,
        bLengthChange: false,
        columnDefs: [
            { type: 'string', targets: [0, 1, 2] }
        ]
    });

    $('#tablausuario').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-ES.json'
        },
        bInfo: false,
        bLengthChange: false,
        columnDefs: [
            { type: 'string', targets: [0, 1, 2] }
        ]
    });

    $('#tablaroles').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-ES.json'
        },
        bInfo: false,
        bLengthChange: false,
        columnDefs: [
            { type: 'string', targets: [0, 1, 2] }
        ]
    });
    $('#tablacarrito').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-ES.json'
        },
        bInfo: false,
        bLengthChange: false,
        columnDefs: [
            { type: 'string', targets: [0, 1, 2,3] }
        ]
    });
}
