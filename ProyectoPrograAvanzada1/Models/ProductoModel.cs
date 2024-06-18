using ProyectoPrograAvanzada1.Entities;
using System.Net.Http.Headers;
using System.Net.Http;
using ProyectoPrograAvanzada1.Services;

namespace ProyectoPrograAvanzada1.Models
{
    public class ProductoModel(HttpClient _httpClient, IConfiguration _configuration, IHttpContextAccessor _context) : IProductoModel
    {
        public ProductoRespuesta? ConsultarProductos(bool MostrarTodos)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Producto/ConsultarProductos?MostrarTodos=" + MostrarTodos;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }

       

        public ProductoRespuesta? ConsultarProducto(long IdProducto)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Producto/ConsultarProducto?IdProducto=" + IdProducto;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }



        public ProductoRespuesta? RegistrarProducto(Producto entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Producto/RegistrarProducto";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }


        public ProductoRespuesta? ActualizarProducto(Producto entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Producto/ActualizarProducto";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }

        public Respuesta? EliminarProducto(long IdProducto)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Producto/EliminarProducto?IdProducto=" + IdProducto;
            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }


    }
}
