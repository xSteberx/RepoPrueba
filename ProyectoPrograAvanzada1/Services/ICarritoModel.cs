using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;

namespace ProyectoPrograAvanzada1.Services
{
    public interface ICarritoModel
    {
        public CarritoRespuesta? ConsultarCarrito(long IdUsuario);
        public CarritoRespuesta? AgregarCarrito(Carrito entidad);
        public CarritoRespuesta? RemueveProducto(long IdProducto);

        Respuesta? PagarCarrito();
    }
}
