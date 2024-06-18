using ProyectoPrograAvanzada1.Entities;

namespace ProyectoPrograAvanzada1.Services
{
    public interface IProductoModel
    {

        public ProductoRespuesta? ConsultarProductos(bool MostrarTodos);
        public ProductoRespuesta? ConsultarProducto(long IdProducto);
        public ProductoRespuesta? RegistrarProducto(Producto entidad);
        public ProductoRespuesta? ActualizarProducto(Producto entidad);
        public Respuesta? EliminarProducto(long IdProducto);



    }
}
