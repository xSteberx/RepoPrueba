using ProyectoPrograAvanzada1.Entities;

namespace ProyectoPrograAvanzada1.Services
{
    public interface IRolModel
    {
        public RolRespuesta? ConsultarRoles();
        public RolRespuesta? ConsultarRolesp(long IdRol);
        public RolRespuesta? tRegistraRol(Rol entidad);
        public RolRespuesta? ActualizaRol(Rol entidad);
        public Respuesta? EliminarRol(long IdRol);
    }
}
