using System.Collections.Generic;

namespace Servire.Services.Dal.Interfaces
{
    // T = El tipo de objeto que vas a devolver (ej: Patente)
    // Y = El objeto "padre" por el cual vas a filtrar (ej: Usuario o Familia)
    public interface IJoinRepository<T, Y>
    {
        List<T> GetByObject(Y obj);
    }
}