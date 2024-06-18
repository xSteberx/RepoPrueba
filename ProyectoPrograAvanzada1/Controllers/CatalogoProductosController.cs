using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;

namespace ProyectoPrograAvanzada1.Controllers
{
	public class CatalogoProductosController(ICategoriaModel _categoriaModel, ICarritoModel _carritomodel) : Controller
	{
		[Seguridad]
		[HttpGet]
		public IActionResult InicioCatalogo()
		{
			return View();
		}

		[Seguridad]
		[HttpGet]
		public IActionResult VerProductosCat(int idcategoria)
		{
            try
            {
				var resp = _categoriaModel.ConsultarProductosCat(idcategoria);

				if (resp?.Codigo == "00")
					return View(resp.Datos);
				
				{
					ViewBag.MsjPantalla = resp?.Mensaje;
					return RedirectToAction("PantallaInicio");
				}
			}catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
		}

		[Seguridad]
		[HttpPost]
        public IActionResult AgregarCarrito(Carrito entidad, long idproducto)
        {
			try
			{
				entidad.IdProducto = idproducto;
				var idUsuarioStr = HttpContext.Session.GetString("IdUsuario");

				if (!string.IsNullOrEmpty(idUsuarioStr) && int.TryParse(idUsuarioStr, out int idUsuario))
				{
					entidad.IdUsuario = idUsuario;
				}

				entidad.Cantidad = 1;
				entidad.Fecha = DateTime.Now;

				var resp = _carritomodel.AgregarCarrito(entidad);
				var cantidadEnCarrito = _carritomodel.ConsultarCarrito(entidad.IdUsuario)?.Datos?.Count;

				if (resp?.Codigo == "00")
				{
					ViewBag.CantidadCarrito = cantidadEnCarrito;
					return Json(new { success = true, cantidadEnCarrito });
				}
				else
				{
					return View();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



    }
}

