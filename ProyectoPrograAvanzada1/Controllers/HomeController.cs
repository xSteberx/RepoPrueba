using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;
using System.Diagnostics;

namespace ProyectoPrograAvanzada1.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0)]
    public class HomeController(IUsuarioModel _usuarioModel, IUtilitariosModel _utilitariosModel) : Controller

    {
		
		[HttpGet]
		public IActionResult Politica()
		{

			return View();
		}
        [HttpGet]
        public IActionResult Politica2()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contacto2()
        {
            return View();
        }
        [HttpGet]
        public IActionResult IniciarSesion()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult RecuperarContrasenna()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult CambiarContraUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CambiarContraUser(Usuario entidad)
        {
            try
            {
                var idUsuarioStr = HttpContext.Session.GetString("IdUsuario");
                entidad.IdUsuario = int.Parse(idUsuarioStr);
                entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna);

                var resp = _usuarioModel.CambiarContraUser(entidad);

				if (resp != null) {
                    return Json(new { success = true, message = "Contraseña actualizada correctamente" });
				}
				else
				{
                    return Json(new { success = false, message = "Contraseña no  actualizada " });
                }

              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

        [HttpGet]
        public IActionResult CambiarContrasenna()
        {
            try
            {
				var usuario = new Usuario();
				usuario.Correo = HttpContext.Session.GetString("Correo");

				return View(usuario);
			}catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
		public IActionResult MostrarMensajeYRedireccionar(string mensaje, int tiempo)
		{
			ViewBag.Mensaje = mensaje;
			ViewBag.Tiempo = tiempo;
			return View();
		}

		[HttpPost]
		public IActionResult CambiarContrasenna(Usuario entidad)
		{
			try
			{
				if (entidad.Contrasenna?.Trim() == entidad.ContrasennaTemporal?.Trim())
				{
					ViewBag.MsjPantalla = "Debe utilizar una contraseña distinta";
					return View();
				}

				entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna!);
				entidad.ContrasennaTemporal = _utilitariosModel.Encrypt(entidad.ContrasennaTemporal!);

				var resp = _usuarioModel.CambiarContrasenna(entidad);

				if (resp?.Codigo == "00")
				{
					return Json(new { success = true });
				}
				else
				{
					return Json(new { success = false });
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



		[HttpPost]
        public IActionResult RecuperarContrasenna(Usuario entidad)
        {
            try
            {
				var resp = _usuarioModel.RecuperarAcceso(entidad);

				if (resp?.Codigo == "00")
					return Json(new { success = true });
				else
				{
					return Json(new { success = false });
				}
			}catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



		[HttpPost]
		public IActionResult IniciarSesion(Usuario entidad)
		{
			try
			{
				entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna!);
				var resp = _usuarioModel.IniciarSesion(entidad);

				if (resp?.Codigo == "00" || resp.Codigo == null)
				{
					HttpContext.Session.SetString("Correo", resp?.Dato?.Correo!);
					HttpContext.Session.SetString("IdUsuario", resp?.Dato?.IdUsuario.ToString()!);
					HttpContext.Session.SetString("Nombre", resp?.Dato?.NombreUsuario!);
					HttpContext.Session.SetString("Token", resp?.Dato?.Token!);
                    HttpContext.Session.SetString("Rol", resp?.Dato?.NombreRol!);
                  
                    if (resp.Dato.EsTemporal)
					{
						return RedirectToAction("CambiarContrasenna", "Home");
					}
					else
					{
						HttpContext.Session.SetString("Login", "true");
						return RedirectToAction("PantallaInicio", "Home");
					}
				}
				else
				{
					ViewBag.MsjPantalla = resp.Mensaje;
					return View(entidad);
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("IniciarSesion","Home");
        }

        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(Usuario entidad)
        {
            try
            {
				entidad.Contrasenna = _utilitariosModel.Encrypt(entidad.Contrasenna);
				var resp = _usuarioModel.RegistrarUsuario(entidad);

				if (resp?.Codigo == "00")
					return RedirectToAction("IniciarSesion", "Home");
				else
				{
					ViewBag.MsjPantalla = resp?.Mensaje;
					return View();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

        [Seguridad]
        [HttpGet]
        public IActionResult PantallaInicio()
        {
			try
			{
				var resp = _categoriaModel.ConsultarCategorias(true);

				if (resp?.Codigo == "00")
					return View(resp.Datos);
				else
				{
					ViewBag.MsjPantalla = resp?.Mensaje;
					return View(new List<Categoria>());
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


    }
}
