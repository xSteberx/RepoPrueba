using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;

namespace ProyectoPrograAvanzada1.Controllers
{
    public class CategoriaController(ICategoriaModel _categoriaModel) : Controller
    {
		/*
		  * Controlador para poder mostrar la vista del inicio -
		  * de las categorias del restaurante Amalusa.
		  */
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}



		/*
		 * Controlador para consultar las categorias del restaurante Amalusa.
		 */
		[HttpGet]
		public IActionResult ConsultarCategorias()
		{
			var resp = _categoriaModel.ConsultarCategorias(true);

			if (resp?.Codigo == "00")
			{
				return View(resp!.Datos);
			}
			else
			{
				ViewBag.MsjPantalla = resp?.Mensaje;
				return View(new List<Categoria>());
			}
		}

        [HttpGet]
        public IActionResult ConsultarCategoriaesp(long IdCategoria)
        {
            var resp = _categoriaModel.ConsultarCategoria(IdCategoria);

            if (resp?.Codigo == "00")
            {
                return Json(resp.Dato);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View(new List<Categoria>());
            }
        }

        /*
		 * Controlador para registrar las categorias del restaurante Amalusa.
		 */
        [HttpGet]
		public IActionResult RegistrarCategoria()
		{
			return View();
		}



		/*
		 * Controlador para registrar las categorias del restaurante Amalusa.
		 */
        [HttpPost]
        public IActionResult tRegistrarCategoria(Categoria entidad)
        {
            try
            {
                var resp = _categoriaModel.RegistrarCategoria(entidad);

                if (resp?.Codigo == "00")
                {
                    return Json(new { success = true });
                }
                else if (resp?.Codigo == "-1")
                {
                    return Json(new { success = false });
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


		/*
		 * Controlador para actualizar las categorias del restaurante Amalusa.
		 */
		[HttpPost]
		public IActionResult tActualizarCategoria(Categoria entidad)
		{
            try
            {
                var resp = _categoriaModel.ActualizarCategoria(entidad);

                if (resp?.Codigo == "00")
                {
                    return Json(new { success = true });
                }
                else 
                {
                    return Json(new { success = false });
                }

            }catch (Exception ex) {
                return BadRequest(ex.Message);
            }
		}

        [HttpPost]
        public IActionResult EliminarCategoria(long IdCategoria)
        {
            var resp = _categoriaModel.EliminarCategoria(IdCategoria);

            if (resp?.Codigo == "00")
            {

                return Json(new { success = true, message = "Categoria eliminada correctamente" });
            }
            else
            {
                return Json(new { success = false, message = "Categoria  no  eliminada " });
            }
        }
    }
}
