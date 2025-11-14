using Servire.Bll.Interfaces;
using Servire.Domain.Entities;

namespace Servire.Bll.Services
{
    public interface IProductoService
    {
        IUnitOfWork GetUoW();
        Producto GetProducto(int id); 
        List<Producto> GetProductos(bool incluirInactivos = false); List<string> GetCategoriasProductos();
        void GuardarProducto(Producto producto);
        void SetActivoProducto(int productoId, bool activo);
      
    }
}