using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;

namespace ProyectoPrograAvanzada1.Controllers
{
	public class CarritoController(ICarritoModel _carritomodel, IHttpContextAccessor _httpContextAccessor) : Controller
	{

        [HttpPost]
        public IActionResult PagarCarrito()
        {
            var resp = _carritomodel.PagarCarrito();

            if (resp?.Codigo == "00")
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [Seguridad]
        [HttpGet]
        public IActionResult Carrito(int IdUsuario)
        {
            try
            {
                var idUsuarioStr = HttpContext.Session.GetString("IdUsuario");

                if (!string.IsNullOrEmpty(idUsuarioStr) && int.TryParse(idUsuarioStr, out int idUsuario))
                {
                    var resp = _carritomodel.ConsultarCarrito(idUsuario);

                    if (resp?.Codigo == "00")
                    {
                        if (resp.Datos == null || resp.Datos.Count == 0) 
                        {
                            return RedirectToAction("PantallaInicio","Home");
                        }
                        else
                        {
                            return View(resp.Datos); 
                        }
                    }
                    else
                    {
                        ViewBag.MsjPantalla = resp?.Mensaje;
                        return RedirectToAction("PantallaInicio", "Home");
                    }
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RemueveProducto(long IdProducto)
        {
            try
            {
                var idUsuarioStr = HttpContext.Session.GetString("IdUsuario");
                var remove = _carritomodel.RemueveProducto(IdProducto);

                if (remove?.Codigo == "00")
                {
                    var carrito = _carritomodel.ConsultarCarrito(int.Parse(idUsuarioStr))?.Datos?.Count;
                    if (carrito == 0)
                    {
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
                else
                {
                    ViewBag.MsjPantalla = remove?.Mensaje;
                    return RedirectToAction("PantallaInicio");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Seguridad]
		[HttpGet]
		public IActionResult ObtenerCantidadCarrito()
		{

			try
			{
				var idUsuarioStr = HttpContext.Session.GetString("IdUsuario");

				if (long.TryParse(idUsuarioStr, out long idUsuario))
				{
					var cantidadEnCarrito = _carritomodel.ConsultarCarrito(idUsuario)?.Datos?.Count;
					return Json(new { success = true, cantidadEnCarrito });
				}
				else
				{
					return Json(new { success = false, errorMessage = "No se pudo obtener la cantidad en el carrito." });
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}

    
