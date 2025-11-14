using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servire.Bll.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IBitacoraService _bitacora;
        private readonly ISessionContext _session;

        public ProductoService(IUnitOfWork uow, IBitacoraService bitacora, ISessionContext session)
        {
            _uow = uow;
            _bitacora = bitacora;
            _session = session;
        }
        public IUnitOfWork GetUoW()
        {
            return _uow;
        }
        private string UsuarioActual() => _session.Username ?? "(sistema)";

        public Producto GetProducto(int id)
        {
            var producto = _uow.ProductoRepository.ObtenerPorId(id);
            if (producto == null)
                throw new Exception("Producto no encontrado.");

            producto.Ingredientes = _uow.IngredienteRepository.ObtenerPorProducto(id).ToList();
            return producto;
        }

        public List<Producto> GetProductos(bool incluirInactivos = false)
        {
            return _uow.ProductoRepository.Listar(incluirInactivos).ToList();
        }
        public List<string> GetCategoriasProductos()
        {
            return _uow.ProductoRepository.ListarCategorias().ToList();
        }

        public void GuardarProducto(Producto producto)
        {
            
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new Exception("El nombre del producto es requerido.");
            if (producto.PrecioVenta <= 0)
                throw new Exception("El precio de venta debe ser mayor a cero.");

            if (_uow.ProductoRepository.ExisteNombre(producto.Nombre, producto.Id))
                throw new Exception("Ya existe un producto con ese nombre.");

            if (producto.Ingredientes == null)
                producto.Ingredientes = new List<Ingrediente>();

            
            if (producto.Id == 0)
            {
                int nuevoProductoId = _uow.ProductoRepository.Crear(producto);
                producto.Id = nuevoProductoId;

              
                _uow.IngredienteRepository.SincronizarReceta(nuevoProductoId, producto.Ingredientes);

                _bitacora.Registrar(UsuarioActual(), "Alta Producto", $"Producto: {producto.Nombre}");
            }
            else
            {
                _uow.ProductoRepository.Actualizar(producto);

                _uow.IngredienteRepository.SincronizarReceta(producto.Id, producto.Ingredientes);

                _bitacora.Registrar(UsuarioActual(), "Modificación Producto", $"Producto: {producto.Nombre} (ID: {producto.Id})");
            }
            _uow.Commit();
        }

        public void SetActivoProducto(int productoId, bool activo)
        {
            var p = _uow.ProductoRepository.ObtenerPorId(productoId);
            if (p == null) throw new Exception("Producto no encontrado.");
            _uow.ProductoRepository.SetActivo(productoId, activo);
            string accion = activo ? "Activación Producto (Carta)" : "Baja Producto (Carta)";
            _bitacora.Registrar(UsuarioActual(), accion, $"Producto: {p.Nombre}");
            _uow.Commit();
        }
    }
}