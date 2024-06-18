using Microsoft.Extensions.Configuration;
using ProyectoPrograAvanzada1.Entities;
using System.Net.Http.Headers;
using System.Net.Http;
using ProyectoPrograAvanzada1.Services;

namespace ProyectoPrograAvanzada1.Models
{
	public class CategoriaModel(HttpClient _httpClient, IConfiguration _configuration, IHttpContextAccessor _context) : ICategoriaModel
	{
		public CategoriaRespuesta? ConsultarCategorias(bool MostrarTodos)
		{
			string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Categoria/ConsultarCategorias?MostrarTodos=" + MostrarTodos;

			string token = _context.HttpContext?.Session.GetString("Token")!;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var resp = _httpClient.GetAsync(url).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<CategoriaRespuesta>().Result;

			return null;
		}

		public CategoriaRespuesta? ConsultarCategoria(long IdCategoria)
		{
			string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Categoria/ConsultarCategoria?IdCategoria=" + IdCategoria;

			string token = _context.HttpContext?.Session.GetString("Token")!;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var resp = _httpClient.GetAsync(url).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<CategoriaRespuesta>().Result;

			return null;
		}

		public Respuesta? RegistrarCategoria(Categoria entidad)
		{
			string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Categoria/RegistrarCategoria";

			string token = _context.HttpContext?.Session.GetString("Token")!;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			JsonContent body = JsonContent.Create(entidad);
			var resp = _httpClient.PostAsync(url, body).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

			return null;
		}


		public Respuesta? ActualizarCategoria(Categoria entidad)
		{
			string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Categoria/ActualizarCategoria";
			string token = _context.HttpContext?.Session.GetString("Token")!;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			JsonContent body = JsonContent.Create(entidad);
			var resp = _httpClient.PutAsync(url, body).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

			return null;
		}



		public ProductoRespuesta? ConsultarProductosCat(int idcategoria)
		{
			string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Categoria/ConsultarProductosCat?idcategoria=" + idcategoria;

			string token = _context.HttpContext?.Session.GetString("Token")!;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var resp = _httpClient.GetAsync(url).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

			return null;
		}

		public Respuesta? EliminarCategoria(long IdCategoria)
		{
			string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Categoria/EliminarCategoria?IdCategoria=" + IdCategoria;
			string token = _context.HttpContext?.Session.GetString("Token")!;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var resp = _httpClient.DeleteAsync(url).Result;

			if (resp.IsSuccessStatusCode)
				return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

			return null;
		}
	}
}
