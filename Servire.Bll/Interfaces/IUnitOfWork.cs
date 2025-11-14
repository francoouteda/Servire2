namespace Servire.Bll.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        IUsuarioRepository UsuarioRepository { get; }
        IBitacoraRepository BitacoraRepository { get; }
        IProveedorRepository ProveedorRepository { get; }
        IInsumoRepository InsumoRepository { get; }
        IMovimientoStockRepository MovimientoStockRepository { get; }
        IProductoRepository ProductoRepository { get; }
        IIngredienteRepository IngredienteRepository { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
     
    }
}