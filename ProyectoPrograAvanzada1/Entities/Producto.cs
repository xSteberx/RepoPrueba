﻿namespace ProyectoPrograAvanzada1.Entities
{
    public class Producto
    {
        public long IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? NombreCategoria { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public short? IdCategoria { get; set; }
        public bool Estado { get; set; }
        public long Stock { get; set; }
        public long ConteoCompras { get; set; }
    }

    public class ProductoRespuesta
    {
        public ProductoRespuesta()
        {
            Codigo = "00";
            Mensaje = string.Empty;
        }

        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }
        public long? Cantidad { get; set; }
        public Producto? Dato { get; set; }
        public List<Producto>? Datos { get; set; }
        public List<Categoria>? Categorias { get; set; }
    }
}
