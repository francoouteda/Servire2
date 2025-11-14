using Servire.Domain.Entities;
using System.Collections.Generic;

namespace Servire.Bll.Interfaces
{
    public interface IProveedorRepository
    {
        Proveedor? ObtenerPorId(int id);
     
        IEnumerable<Proveedor> Listar(bool incluirInactivos);
        void Crear(Proveedor proveedor);
        void Actualizar(Proveedor proveedor);
        IEnumerable<string> ListarCategorias();

        void SetActivo(int proveedorId, bool activo);
    }
}