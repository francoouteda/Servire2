using Servire.Domain.Entities;

namespace Servire.Bll.Interfaces
{
   
    public interface IBitacoraService
    {
        IUnitOfWork GetUoW();
        void Registrar(string username, string accion, string mensaje);
        IEnumerable<Bitacora> Listar(DateTime desde, DateTime hasta);
    }
}