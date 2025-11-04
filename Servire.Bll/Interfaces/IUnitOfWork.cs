// Servire.Bll/Interfaces/IUnitOfWork.cs
namespace Servire.Bll.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Propiedades para acceder a cada repositorio
        IUsuarioRepository UsuarioRepository { get; }
        IBitacoraRepository BitacoraRepository { get; }
        // IProductoRepository ProductoRepository { get; }

        // Método para confirmar la transacción

        IErrorLogRepository ErrorLogRepository { get; }
        void Commit();
        void Rollback();
    }
}