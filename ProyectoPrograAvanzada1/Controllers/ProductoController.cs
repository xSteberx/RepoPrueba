using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;

namespace ProyectoPrograAvanzada1.Controllers
{
    public class ProductoController(IProductoModel _productoModel,ICategoriaModel _categoriaModel, IHostEnvironment _environment) : Controller
    {


        [Seguridad]
        [HttpGet]
        public IActionResult ConsultarProductos()
        {
            var resp = _productoModel.ConsultarProductos(true);

            if (resp?.Codigo == "00")
            {
                var categoriasRespuesta = _categoriaModel.ConsultarCategorias(true);
                if (categoriasRespuesta?.Codigo == "00")
                {
                    ViewBag.Categorias = categoriasRespuesta.Datos;
                    return View(resp.Datos);
                }
                else
                {
                    ViewBag.MensajeCategorias = categoriasRespuesta?.Mensaje;
                }
                return View(resp.Datos);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View(new List<Usuario>());
            }
        }

       

        [Seguridad]
        [HttpGet]
        public IActionResult ConsultarProductoesp(long IdProducto)
        {
            var resp = _productoModel.ConsultarProducto(IdProducto);

            if (resp?.Codigo == "00")
                return Json(resp.Dato);
            else
            {
                return Json(null);
            }
        }


        [HttpPost]
        public IActionResult tRegistrarProducto(IFormFile Imagen, Producto entidad)
        {
            if (Imagen != null && Imagen.Length > 0)
            {
                string ext = Path.GetExtension(Path.GetFileName(Imagen.FileName));
                string folder = Path.Combine(_environment.ContentRootPath, "wwwroot\\Imagenes");

                if (ext.ToLower() != ".png")
                {
                    ViewBag.MsjPantalla = "La imagen debe ser .png";
                    return View();
                }

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

       
                string fileName = Guid.NewGuid().ToString() + ext;
                string filePath = Path.Combine(folder, fileName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Imagen.CopyTo(fileStream);
                }

                string rutaCompletaImagen = "/Imagenes/" + fileName;

                entidad.Imagen = rutaCompletaImagen;
            }

            var resp = _productoModel.RegistrarProducto(entidad);

            if (resp?.Codigo == "00")
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }



        [HttpPost]
        public IActionResult tActualizarProducto(IFormFile ImagenProd, Producto entidad)
        {
            string ext = string.Empty;
            string folder = string.Empty;

            if (ImagenProd != null)
            {
                ext = Path.GetExtension(Path.GetFileName(ImagenProd.FileName));
                folder = Path.Combine(_environment.ContentRootPath, "wwwroot\\Imagenes");

                if (ext.ToLower() != ".png")
                {
                    ViewBag.MsjPantalla = "La imagen debe ser .png";
                    return View();
                }

                string fileName = Guid.NewGuid().ToString() + ext;
                string filePath = Path.Combine(folder, fileName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ImagenProd.CopyTo(fileStream);
                }

                string rutaCompletaImagen = "/Imagenes/" + fileName;

                entidad.Imagen = rutaCompletaImagen;
            }
            else
            {
                var resp2 = _productoModel.ConsultarProducto(entidad.IdProducto);

                entidad.Imagen = resp2.Dato.Imagen;
            }
           
            var resp = _productoModel.ActualizarProducto(entidad);

            if (resp?.Codigo == "00")
            {
                if (ImagenProd != null)
                {
                    string archivo = Path.Combine(folder, entidad.IdProducto + ext);
                    using (Stream fileStream = new FileStream(archivo, FileMode.Create))
                    {
                        ImagenProd.CopyTo(fileStream);
                    }
                }
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public IActionResult EliminarProducto(long IdProducto)
        {
            var resp = _productoModel.EliminarProducto(IdProducto);

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
