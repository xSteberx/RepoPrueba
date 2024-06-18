using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;
namespace ProyectoPrograAvanzada1.Controllers
{
    public class ReporteController(IReporteModel _reporteModel) : Controller
    {
        [Seguridad]
        [HttpGet]
        public IActionResult CantidadUsuariosAct()
        {
            var resp = _reporteModel.CantidadUsuariosAct();

            if (resp?.Codigo == "00")
                return Json(resp);
            else
                return Json(new { success = false });
        }
        [Seguridad]
        [HttpGet]
        public IActionResult ConsultarStockProductos()
        {
            var resp = _reporteModel.ConsultarStockProductos();

            if (resp?.Codigo == "00")
                return Json(resp.Datos);
            else
                return Json(new { success = false });
        }

        [Seguridad]
        [HttpGet]
        public IActionResult ConsultaProductosCont()
        {
            var resp = _reporteModel.ConsultaProductosCont();

            if (resp?.Codigo == "00")
                return Json(resp.Datos);
            else
                return Json(new { success = false });
        }

        [Seguridad]
        [HttpGet]
        public IActionResult ConsultaVentasDia()
        {
            var resp = _reporteModel.ConsultaVentasDia();

            if (resp?.Codigo == "00")
                return Json(resp);
            else
                return Json(new { success = false });
        }
        [Seguridad]
        [HttpGet]
        public IActionResult ConsultaVentasMensual()
        {
            var resp = _reporteModel.ReporteVentasMensual();

            if (resp?.Codigo == "00")
                return Json(resp.Datos);
            else
                return Json(new { success = false });
        }
    }
}
