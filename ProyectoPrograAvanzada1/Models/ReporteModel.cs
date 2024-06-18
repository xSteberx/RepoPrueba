using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Services;
using System.Net.Http.Headers;


namespace ProyectoPrograAvanzada1.Models
{
    public class ReporteModel(HttpClient _httpClient, IConfiguration _configuration, IHttpContextAccessor _context) : IReporteModel
    {
       


        public UsuarioRespuesta? CantidadUsuariosAct()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Reportes/CantidadUsuariosAct";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public ProductoRespuesta? ConsultaProductosCont()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Reportes/ConsultaProductosCont";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }

        public ProductoRespuesta? ConsultarStockProductos()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Reportes/ConsultarStockProductos";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }
        public VentaRespuesta? ReporteVentasMensual()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Reportes/ReporteVentasMensual";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<VentaRespuesta>().Result;

            return null;
        }
        public VentaRespuesta? ConsultaVentasDia()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Reportes/ConsultaVentasDia";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<VentaRespuesta>().Result;

            return null;
        }
    }
}
