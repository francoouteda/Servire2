using Servire.Domain.Entities; // <-- Asegúrate de tener este 'using'

namespace Servire.Bll.Interfaces
{
    public interface IBitacoraRepository
    {
        // La firma correcta: recibe la entidad completa
        void Registrar(Bitacora bitacora);

        IEnumerable<Bitacora> Listar(DateTime desde, DateTime hasta);
    }
}