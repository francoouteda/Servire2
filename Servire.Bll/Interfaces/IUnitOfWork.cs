namespace Servire.Bll.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       


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