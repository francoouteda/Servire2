using Servire.Domain.Entities;

namespace Servire.Bll.Interfaces
{
    // Este es el contrato para la capa de NEGOCIO (BLL)
    // Tu UI (frmBitacora) dependerá de esto.
    public interface IBitacoraService
    {
        void Registrar(string username, string accion, string mensaje);
        IEnumerable<Bitacora> Listar(DateTime desde, DateTime hasta);
    }
}