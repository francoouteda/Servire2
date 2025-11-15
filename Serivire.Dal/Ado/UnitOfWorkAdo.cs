using Microsoft.Data.SqlClient;

using Servire.Bll.Interfaces;
using System.Data.SqlTypes;

namespace Servire.Dal.Ado
{
    public class UnitOfWorkAdo : IUnitOfWork
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        private bool _disposed;

        
        private IProveedorRepository _proveedorRepository;
        private IInsumoRepository _insumoRepository;
        private IMovimientoStockRepository _movimientoStockRepository;
        private IProductoRepository _productoRepository;
        private IIngredienteRepository _ingredienteRepository;

        public UnitOfWorkAdo(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

       
     
        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction already started.");
            }
            _transaction = _connection.BeginTransaction();
        }
        public IProveedorRepository ProveedorRepository =>
            _proveedorRepository ??= new ProveedorRepositoryAdo(_connection, _transaction);

        public IInsumoRepository InsumoRepository =>
            _insumoRepository ??= new InsumoRepositoryAdo(_connection, _transaction);

        public IMovimientoStockRepository MovimientoStockRepository =>
            _movimientoStockRepository ??= new MovimientoStockRepositoryAdo(_connection, _transaction);

    

        public IProductoRepository ProductoRepository =>
            _productoRepository ??= new ProductoRepositoryAdo(_connection, _transaction);

        public IIngredienteRepository IngredienteRepository =>
            _ingredienteRepository ??= new IngredienteRepositoryAdo(_connection, _transaction);

        public void Commit()
        {
            if (_transaction == null) return;

            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                ReiniciarTransaccion();
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            ReiniciarTransaccion();
        }

        private void ReiniciarTransaccion()
        {
            _transaction?.Dispose();
            _transaction = null;

           
        
            _proveedorRepository = null;
            _insumoRepository = null;
            _movimientoStockRepository = null;
            _productoRepository = null;
            _ingredienteRepository = null;
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