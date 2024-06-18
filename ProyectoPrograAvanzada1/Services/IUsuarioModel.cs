using ProyectoPrograAvanzada1.Entities;

namespace ProyectoPrograAvanzada1.Services
{
    public interface IUsuarioModel
    {
        public Respuesta? RegistrarUsuario(Usuario Entidad);
        public Respuesta? tRegistrarUsuario(Usuario entidad);
        public UsuarioRespuesta? IniciarSesion(Usuario Entidad);
        public UsuarioRespuesta? CambiarContrasenna(Usuario Entidad);
        public UsuarioRespuesta? RecuperarAcceso(Usuario entidad);
        public UsuarioRespuesta? CambiarContraUser(Usuario entidad);
        public UsuarioRespuesta? ConsultarUsuarios();
        public UsuarioRespuesta? ConsultarUsuario(long IdUsuario);
        public Respuesta? EliminarUsuario(long IdUsuario);
        public UsuarioRespuesta? ActualizarUsuario(Usuario entidad);

    }
}
