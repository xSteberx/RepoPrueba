using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;

namespace ProyectoPrograAvanzada1.Services
{
    public interface IComprasModel
    {
        ComprasRespuesta? ConsultarCompras();
        ComprasRespuesta? ConsultarDetalleCompras(long IdCompra);
        ComprasRespuesta? ConsultarComprasMensuales();
    }
}
