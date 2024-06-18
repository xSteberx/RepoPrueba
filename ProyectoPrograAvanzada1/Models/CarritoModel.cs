using Microsoft.Extensions.Configuration;
using ProyectoPrograAvanzada1.Entities;
using ProyectoPrograAvanzada1.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProyectoPrograAvanzada1.Models
{
    public class CarritoModel (HttpClient _httpClient,IConfiguration _configuration, IHttpContextAccessor _context) : ICarritoModel
    {

        public Respuesta? PagarCarrito()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Carrito/PagarCarrito";
            JsonContent body = JsonContent.Create(new Carrito());

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }
        public CarritoRespuesta? ConsultarCarrito(long IdUsuario)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Carrito/ConsultarCarrito?IdUsuario=" + IdUsuario;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CarritoRespuesta>().Result;

            return null;
        }

        public CarritoRespuesta? AgregarCarrito(Carrito entidad)
		{
			string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Carrito/AgregarCarrito";
			JsonContent body = JsonContent.Create(entidad);
			var resp = _httpClient.PostAsync(url, body).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<CarritoRespuesta>().Result;

			return null;
		}

        public CarritoRespuesta? RemueveProducto(long IdProducto)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Carrito/RemueveProducto?IdProducto=" + IdProducto;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var resp = _httpClient.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CarritoRespuesta>().Result;

            return null;
        }



    }
}
