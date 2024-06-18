using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Services;
using System.Net.Http.Headers;


namespace ProyectoPrograAvanzada1.Models
{
    public class RolModel(HttpClient _httpClient, IConfiguration _configuration, IHttpContextAccessor _context) : IRolModel
    {
        public RolRespuesta? ConsultarRoles()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Rol/ConsultarRoles";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<RolRespuesta>().Result;

            return null;
        }
        public RolRespuesta? ConsultarRolesp(long IdRol)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Rol/ConsultaRolesp?IdRol=" + IdRol;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<RolRespuesta>().Result;

            return null;
        }

        public RolRespuesta? tRegistraRol(Rol entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Rol/RegistraRol";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<RolRespuesta>().Result;

            return null;
        }
        public RolRespuesta? ActualizaRol(Rol entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Rol/tActualizaRol";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<RolRespuesta>().Result;

            return null;
        }

        public Respuesta? EliminarRol(long IdRol)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Rol/EliminarRol?IdRol=" + IdRol;
            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }


    }
}
