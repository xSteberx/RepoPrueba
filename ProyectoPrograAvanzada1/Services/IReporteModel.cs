using ProyectoPrograAvanzada1.Entities;

namespace ProyectoPrograAvanzada1.Services
{
    public interface IReporteModel
    {
        public UsuarioRespuesta? CantidadUsuariosAct();
        public ProductoRespuesta? ConsultarStockProductos();
        public VentaRespuesta? ConsultaVentasDia();
        public VentaRespuesta? ReporteVentasMensual();
        public ProductoRespuesta? ConsultaProductosCont();
    }
}
