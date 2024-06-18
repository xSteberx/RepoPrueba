using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;

namespace ProyectoPrograAvanzada1.Controllers
{
	public class UsuarioController(IUsuarioModel _usuarioModel,IRolModel _rolModel, IUtilitariosModel _utilitariosModel) : Controller
	{
		



            [Seguridad]
            [HttpGet]
            public IActionResult ConsultarUsuarios()
            {
                var resp = _usuarioModel.ConsultarUsuarios();

            if (resp?.Codigo == "00")
            {
                var rolresp = _rolModel.ConsultarRoles();
                if (rolresp?.Codigo == "00")
                {
                    ViewBag.Roles = rolresp.Datos;
                    return View(resp.Datos);
                }
                else
                {
                    ViewBag.MensajeRoles = rolresp?.Mensaje;
                }
                return View(resp.Datos);
            } else{
                    ViewBag.MsjPantalla = resp?.Mensaje;
                    return View(new List<Usuario>());
                }
            }

        [Seguridad]
        [HttpGet]
        public IActionResult ConsultarUsuarioesp(long IdUsuario)
        {
            var resp = _usuarioModel.ConsultarUsuario(IdUsuario);

            if (resp?.Codigo == "00")
                return Json(resp.Dato);
            else
            {
                return Json(null);
            }
        }
     

        [Seguridad]
        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            var rolresp = _rolModel.ConsultarRoles();

            if (rolresp?.Codigo == "00")
            {
                ViewBag.Roles = rolresp.Datos;
            }
            else
            {
                ViewBag.MensajeRoles = rolresp?.Mensaje;
            }

            return View();
        }

        [HttpPost]
        public IActionResult tRegistrarUsuario(Usuario entidad)
        {
            try
            {
  
                var resp = _usuarioModel.tRegistrarUsuario(entidad);

                if (resp?.Codigo == "00")
                {
                    return Json(new { success = true });
                }
                else if (resp?.Codigo == "-1")
                {
                    return Json(new { success = false});
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult tActualizarUsuario(Usuario entidad)
        {
            
            try
            {
                var resp = _usuarioModel.ActualizarUsuario(entidad);

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
        


        [HttpPost]
        public IActionResult EliminarUsuario(long IdUsuario)
        {
            var resp = _usuarioModel.EliminarUsuario(IdUsuario);

            if (resp?.Codigo == "00")
            {

                return Json(new { success = true, message = "Usuario eliminado correctamente" });
            }
            else
            {
                return Json(new { success = false, message = "Usuario  no  eliminado " });
            }
        }
    }
}
