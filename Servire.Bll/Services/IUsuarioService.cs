using Servire.Domain.Entities;

namespace Servire.Bll;

public interface IUsuarioService
{
    Usuario Login(string username, string password);
    IEnumerable<Usuario> Listar();
    Usuario? ObtenerPorId(int id);
    void Crear(Usuario u, string passwordPlano);
    void Actualizar(Usuario u);
    void CambiarPassword(int userId, string nuevoPassword);
    void ToggleActivo(int userId, bool activo);
    void Validar(Usuario u); 
}