using Servire.Domain.Entities;
using System.Collections.Generic;

namespace Servire.Bll.Interfaces
{
    public interface IIngredienteRepository
    {
        
        IEnumerable<Ingrediente> ObtenerPorProducto(int productoId);

        
        void SincronizarReceta(int productoId, List<Ingrediente> ingredientes);
    }
}