using ProyectoPrograAvanzada1.Services;
using ProyectoPrograAvanzada1.Entities;
using System.Net.Http.Headers;
namespace ProyectoPrograAvanzada1.Models
{
    public class ComprasModel(HttpClient _httpClient, IConfiguration _configuration, IHttpContextAccessor _context) : IComprasModel
    {

        public ComprasRespuesta? ConsultarCompras()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Compras/ConsultarCompras";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ComprasRespuesta>().Result;

            return null;
        }


        public ComprasRespuesta? ConsultarDetalleCompras(long IdCompra)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Compras/ConsultarDetalleCompras?IdCompra=" + IdCompra;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ComprasRespuesta>().Result;

            return null;
        }


        public ComprasRespuesta? ConsultarComprasMensuales()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Compras/ConsultarComprasMensuales";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ComprasRespuesta>().Result;

            return null;
        }

    }
}
