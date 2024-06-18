using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Services;
using System.Net.Http.Headers;


namespace ProyectoPrograAvanzada1.Models
{
    public class UsuarioModel(HttpClient _httpClient, IConfiguration _configuration, IHttpContextAccessor _context) : IUsuarioModel
    {
        public Respuesta? RegistrarUsuario(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/RegistrarUsuario";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }

        public Respuesta? tRegistrarUsuario(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/tRegistrarUsuario";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? IniciarSesion(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/IniciarSesion";
            JsonContent body = JsonContent.Create(entidad);

          
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? RecuperarAcceso(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/RecuperarAcceso";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? CambiarContrasenna(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/CambiarContrasenna";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }
        public UsuarioRespuesta? CambiarContraUser(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/CambiarContraUser";
            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }


        public UsuarioRespuesta? ConsultarUsuarios()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/ConsultarUsuarios";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? ConsultarUsuario(long IdUsuario)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/ConsultarUsuario?IdUsuario=" + IdUsuario;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? ActualizarUsuario(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/ActualizarUsuario";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public Respuesta? EliminarUsuario(long IdUsuario)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/EliminarUsuario?IdUsuario=" + IdUsuario;
            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }


    }
}
