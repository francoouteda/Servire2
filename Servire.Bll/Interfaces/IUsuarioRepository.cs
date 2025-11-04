using Servire.Domain.Entities;


namespace Servire.Bll.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? ObtenerPorId(int id);
        Usuario? ObtenerPorUsername(string username);
        IEnumerable<Usuario> Listar();
        void Crear(Usuario u);
        void Actualizar(Usuario u);
        bool ExisteUsername(string username, int idIgnorar = 0);
        bool ExisteDni(string dni, int idIgnorar = 0);
    }
}