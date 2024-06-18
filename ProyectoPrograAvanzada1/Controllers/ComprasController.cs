using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Services;


namespace ProyectoPrograAvanzada1.Controllers
{
    public class ComprasController(IComprasModel _comprasModel) : Controller
    {

        public IActionResult ConsultarCompras()
        {
            var resp = _comprasModel.ConsultarCompras();

            if (resp?.Codigo == "00")
            {
                return View(resp.Datos);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View(new List<Compras>());
            }
        }


        public IActionResult ConsultarDetalleCompras(long IdCompra)
        {
            var resp = _comprasModel.ConsultarDetalleCompras(IdCompra);

            if (resp?.Codigo == "00")
            {
                return Json(resp.Datos);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View(new List<Compras>());
            }
        }

        public IActionResult ConsultarComprasAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetChartData()
        {
            var resp = _comprasModel.ConsultarComprasMensuales();

            return Json(resp!.Datos);
        }



    }
}
