document.addEventListener('DOMContentLoaded', () => {
    fetch('/Reporte/CantidadUsuariosAct')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener la cantidad de usuarios activos');
            }
            return response.json();
        })
        .then(data => {
            if (data && data.cantidad > 0) {
                document.getElementById('numeroUsuarios').innerText = data.cantidad;
            } else {
                document.getElementById('numeroUsuarios').innerText = 0;
            }
        })
   
    fetch('/Reporte/ConsultarStockProductos')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener la cantidad de producto ');
            }
            return response.json();
        })
        .then(data => {
            var arrayNombres = [];
            var arrayStock = [];

            for (var i = 0; i < data.length; i++) {

                arrayNombres.push(data[i].nombre)
                arrayStock.push(data[i].stock)
            }
            var controlBar1 = document.getElementById("reporteproductos");

            var graficoBar1 = new Chart(controlBar1, {
                type: 'bar',
                data: {
                    labels: arrayNombres,
                    datasets: [{
                        label: "Productos en Stock",
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 205, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(201, 203, 207, 0.2)'
                        ],
                        borderColor: [
                            'rgb(255, 99, 132)',
                            'rgb(255, 159, 64)',
                            'rgb(255, 205, 86)',
                            'rgb(75, 192, 192)',
                            'rgb(54, 162, 235)',
                            'rgb(153, 102, 255)',
                            'rgb(201, 203, 207)'
                        ],
                        borderColor: "#000000",
                        borderWidth: 1,
                        data: arrayStock,
                    }],
                }
            });
        })
        .catch(error => {
            console.error(error);
        });

    fetch('/Reporte/ConsultaVentasDia')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener las ventas del mes ');
            }
            return response.json();
        })
        .then(data => {
            if (data && data.cantidad > 0) {
                document.getElementById('numeroVentas').innerText = data.cantidad;
            } else {
                document.getElementById('numeroVentas').innerText = 0;
            }
        })
        .catch(error => {
            console.error(error);
        });

    fetch('/Reporte/ConsultaVentasMensual')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener las ventas del mes ');
            }
            return response.json();
        })
        .then(data => {
            var arrayMeses = [];
            var arrayCantidad = [];

            for (var i = 0; i < data.length; i++) {

                arrayMeses.push(data[i].mes)
                arrayCantidad.push(parseInt(data[i].cantidad));
            }
            var controlBar1 = document.getElementById("reporteventasmensual");
            var graficoBar1 = new Chart(controlBar1, {
                type: 'bar',
                data: {
                    labels: arrayMeses,
                    datasets: [{
                        label: "Ventas Por Mes",
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 205, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(201, 203, 207, 0.2)'
                        ],
                        borderColor: [
                            'rgb(255, 99, 132)',
                            'rgb(255, 159, 64)',
                            'rgb(255, 205, 86)',
                            'rgb(75, 192, 192)',
                            'rgb(54, 162, 235)',
                            'rgb(153, 102, 255)',
                            'rgb(201, 203, 207)'
                        ],
                        borderColor: "#000000",
                        borderWidth: 1,
                        data: arrayCantidad,
                    }]
                }

            })


        })
        .catch(error => {
            console.error(error);
        });

    fetch('/Reporte/ConsultaProductosCont')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener el promedio de productos ');
            }
            return response.json();
        })
        .then(data => {
            var arrayNombres = [];
            var arrayCantidad = [];

            for (var i = 0; i < data.length; i++) {

                arrayNombres.push(data[i].nombre)
                arrayCantidad.push(parseInt(data[i].conteoCompras));
            }

            var controlBar3 = document.getElementById("reportecontproductos");
            var graficoBar2 = new Chart(controlBar3, {
                type: 'line',
                options: {
                    plugins: {
                        title: {
                            display: true,
                            text: 'Promedio de Productos más Vendidos',
                            font: {
                                size: 18,
                                weight: 'bold'
                            }
                        },
                        legend: {
                            display: true,
                            position: 'bottom',
                            labels: {
                                font: {
                                    size: 14
                                }
                            }
                        }
                    },
                    scales: {
                        y: {
                            stacked: true,
                            ticks: {
                                beginAtZero: true,
                                font: {
                                    size: 14
                                }
                            }
                        },
                        x: {
                            ticks: {
                                font: {
                                    size: 14
                                }
                            }
                        }
                    },
                    animation: {
                        duration: 1500,
                        easing: 'easeInOutQuart'
                    }
                },
                data: {
                    labels: arrayNombres,
                    datasets: [{
                        label: "Promedios",
                        backgroundColor: 'rgba(54, 162, 235, 0.2)',
                        borderColor: 'rgb(54, 162, 235)',
                        borderWidth: 2,
                        pointBackgroundColor: 'rgb(54, 162, 235)',
                        pointBorderColor: 'rgb(54, 162, 235)',
                        pointHoverBackgroundColor: 'rgb(54, 162, 235)',
                        pointHoverBorderColor: 'rgb(54, 162, 235)',
                        data: arrayCantidad,
                    }]
                }
            });


        })
        .catch(error => {
            console.error(error);
        });
});

