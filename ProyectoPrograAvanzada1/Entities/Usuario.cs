﻿namespace ProyectoPrograAvanzada1.Entities
{
    public class Usuario
    {
        public long IdUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Contrasenna { get; set; }
        public string? NombreUsuario { get; set; }
        public short IdRol { get; set; }
        public string? NombreRol { get; set; }
        public bool Estado { get; set; }
        public string? Token { get; set; }
        public bool EsTemporal { get; set; }
        public string? ContrasennaTemporal { get; set; }
        public string? ContrasennaNueva { get; set; }
        public short IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
        public long Cantidad { get; set; }

    }

    public class UsuarioRespuesta
    {
        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }
        public int? Cantidad { get; set; }
        public Usuario? Dato { get; set; }
        public List<Usuario>? Datos { get; set; }
    }
}

