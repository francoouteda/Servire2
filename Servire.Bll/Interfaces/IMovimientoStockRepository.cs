using Servire.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Servire.Bll.Interfaces
{
    public interface IMovimientoStockRepository
    {
        void Registrar(MovimientoStock movimiento);
        IEnumerable<MovimientoStock> ListarPorInsumo(int insumoId, DateTime desde, DateTime hasta);
    }
}