using Servire.Domain.Entities; 

namespace Servire.Bll.Interfaces
{
    public interface IBitacoraRepository
    {
        
        void Registrar(Bitacora bitacora);

        IEnumerable<Bitacora> Listar(DateTime desde, DateTime hasta);
    }
}