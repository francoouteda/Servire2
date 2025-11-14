using Servire.Domain.Entities;
using System.Collections.Generic;

namespace Servire.Bll.Interfaces
{
    public interface IInsumoRepository
    {
        Insumo? ObtenerPorId(int id);
        IEnumerable<Insumo> Listar();
        void Crear(Insumo insumo);
        void Actualizar(Insumo insumo);

        IEnumerable<Insumo> ListarStockCritico();
        bool ExisteNombre(string nombre, int idIgnorar = 0);

        IEnumerable<string> ListarCategorias();

        IEnumerable<Insumo> ListarActivosPorProveedor(int proveedorId);
    }
}