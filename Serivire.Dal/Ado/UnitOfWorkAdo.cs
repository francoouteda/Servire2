using Microsoft.Data.SqlClient;
using Servire.Bll.DTOs;
using Servire.Bll.Interfaces;
using System.Data.SqlTypes;
namespace Servire.Dal.Ado

{
    public class UnitOfWorkAdo : IUnitOfWork
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        private bool _disposed;

        // Repositorios (se inicializan "lazy" para usar la misma transacción)
        private IBitacoraRepository _bitacoraRepository;
        private IUsuarioRepository _usuarioRepository; // (Se agregará después)
        private IErrorLogRepository _errorLogRepository;


        public UnitOfWorkAdo(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        // Propiedad de la interfaz (implementación "lazy loading")
        public IBitacoraRepository BitacoraRepository =>
            _bitacoraRepository ??= new BitacoraRepositoryAdo(_transaction);

        public IUsuarioRepository UsuarioRepository => 
            _usuarioRepository ??= new UsuarioRepositoryAdo(_transaction);

        public IErrorLogRepository ErrorLogRepository => _errorLogRepository ??= new ErrorLogRepositoryAdo(_transaction);
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw; // Relanza la excepción
            }
            finally
            {
                // Inicia una nueva transacción para el próximo trabajo
                ReiniciarTransaccion();

                _errorLogRepository = null;
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            ReiniciarTransaccion();
        }

        private void ReiniciarTransaccion()
        {
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
            // Resetea los repositorios para que usen la nueva transacción
            _bitacoraRepository = null;
             _usuarioRepository = null;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _transaction?.Dispose();
            _connection?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}