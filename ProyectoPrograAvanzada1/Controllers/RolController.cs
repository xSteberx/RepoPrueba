using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;


namespace ProyectoPrograAvanzada1.Controllers
{
    public class RolController(IRolModel _rolModel) : Controller
    {
        [Seguridad]
        [HttpGet]
        public IActionResult ConsultarRoles()
        {
            var resp = _rolModel.ConsultarRoles();

            if (resp?.Codigo == "00")
                return View(resp.Datos);
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View(new List<Rol>());
            }
        }

        [Seguridad]
        [HttpGet]
        public IActionResult ConsultarRolesp(long IdRol)
        {
            var resp = _rolModel.ConsultarRolesp(IdRol);

            if (resp?.Codigo == "00")
                 return Json(resp.Dato);
            else
            {
                return Json(null); 
            }
        }

        [HttpPost]
        public IActionResult tActualizaRol(Rol entidad)
        {
            try
            {
                var resp = _rolModel.ActualizaRol(entidad);

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
        public IActionResult tRegistrarRol(Rol entidad)
        {
            try
            {
                var resp = _rolModel.tRegistraRol(entidad);

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
        public IActionResult EliminarRol(long IdRol)
        {
            var resp = _rolModel.EliminarRol(IdRol);

            if (resp?.Codigo == "00")
            {

                return Json(new { success = true, message = "Rol eliminado correctamente" });
            }
            else
            {
                return Json(new { success = false, message = "Rol  no  eliminado " });
            }
        }
    }
}
