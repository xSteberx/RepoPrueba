using ProyectoPrograAvanzada1.Entities;

namespace ProyectoPrograAvanzada1.Services
{
	public interface ICategoriaModel
	{
		CategoriaRespuesta? ConsultarCategorias(bool MostrarTodos);

		CategoriaRespuesta? ConsultarCategoria(long IdCategoria);

		Respuesta? RegistrarCategoria(Categoria entidad);

		Respuesta? ActualizarCategoria(Categoria entidad);

		ProductoRespuesta? ConsultarProductosCat(int idcategoria);
		public Respuesta? EliminarCategoria(long IdCategoria);
	}
}
