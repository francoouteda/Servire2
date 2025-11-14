using Servire.Domain.Entities;

namespace Servire.Bll.Interfaces
{
    public interface IProductoRepository
    {
        Producto? ObtenerPorId(int id);
        IEnumerable<Producto> Listar(bool incluirInactivos); int Crear(Producto producto); 
        void Actualizar(Producto producto);
        void SetActivo(int productoId, bool activo); bool ExisteNombre(string nombre, int idIgnorar = 0);
        IEnumerable<string> ListarCategorias();
    }
}