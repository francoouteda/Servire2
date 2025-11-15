using Servire.Domain.Entities;
using System;
using Servire.Bll.Interfaces;
using Microsoft.Extensions.Logging;

namespace Servire.Bll.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _uow;
        //private readonly IBitacoraService _bitacora;
        private readonly ILogger _bitacora;
        private readonly ISessionContext _session;

        public IUnitOfWork GetUoW()
        {
            return _uow;
        }

        public StockService(IUnitOfWork uow, ILogger bitacora, ISessionContext session)
        {
            _uow = uow;
            _bitacora = bitacora;
            _session = session;
        }


        private string UsuarioActual() => _session.Username ?? "(sistema)";

        #region Gestión de Insumos

        public List<Insumo> GetInsumos()
        {
            return _uow.InsumoRepository.Listar().ToList();
        }

        public Insumo GetInsumo(int id)
        {
            var insumo = _uow.InsumoRepository.ObtenerPorId(id);
            if (insumo == null)
                throw new Exception("Insumo no encontrado.");
            return insumo;
        }

        public void GuardarInsumo(Insumo insumo)
        {
            if (insumo == null) throw new ArgumentNullException(nameof(insumo));
            if (string.IsNullOrWhiteSpace(insumo.Nombre))
                throw new Exception("El nombre del insumo es requerido.");
            if (string.IsNullOrWhiteSpace(insumo.UnidadMedida))
                throw new Exception("La unidad de medida es requerida.");
            if (insumo.StockMinimo < 0)
                throw new Exception("El stock mínimo no puede ser negativo.");

            if (insumo.EsVendible && insumo.PrecioVenta <= 0)
                throw new Exception("Si el insumo es 'Vendible', debe tener un Precio de Venta mayor a cero.");
            if (!insumo.EsVendible)
                insumo.PrecioVenta = 0;

            if (insumo.CostoUnitario < 0)
                throw new Exception("El Costo Unitario no puede ser negativo.");

            if (!insumo.EsVendible)
                insumo.PrecioVenta = 0;


            if (_uow.InsumoRepository.ExisteNombre(insumo.Nombre, insumo.Id))
                throw new Exception("Ya existe un insumo con ese nombre.");

            if (insumo.Id == 0)
            {
                _uow.InsumoRepository.Crear(insumo);
                _bitacora.Registrar(UsuarioActual(), "Alta Insumo", $"Insumo: {insumo.Nombre}");
            }
            else
            {
                _uow.InsumoRepository.Actualizar(insumo);
                _bitacora.Registrar(UsuarioActual(), "Modificación Insumo", $"Insumo: {insumo.Nombre} (ID: {insumo.Id})");
            }

            _uow.Commit();
        }

        
        public List<Proveedor> GetProveedores(bool incluirInactivos = false)
        {
            return _uow.ProveedorRepository.Listar(incluirInactivos).ToList();
        }

        public void GuardarProveedor(Proveedor proveedor)
        {
            if (proveedor == null) throw new ArgumentNullException(nameof(proveedor));
            if (string.IsNullOrWhiteSpace(proveedor.Nombre))
                throw new Exception("El nombre del proveedor es requerido.");

            if (proveedor.Id == 0)
            {
                _uow.ProveedorRepository.Crear(proveedor);
                _bitacora.Registrar(UsuarioActual(), "Alta Proveedor", $"Proveedor: {proveedor.Nombre}");
            }
            else
            {
                _uow.ProveedorRepository.Actualizar(proveedor);
                _bitacora.Registrar(UsuarioActual(), "Modificación Proveedor", $"Proveedor: {proveedor.Nombre} (ID: {proveedor.Id})");
            }

            _uow.Commit();
        }

        
        public void RegistrarEntrada(int insumoId, decimal cantidad, int usuarioId, string? nroFactura = null)
        {
            if (cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");

            var insumo = _uow.InsumoRepository.ObtenerPorId(insumoId);
            if (insumo == null)
                throw new Exception("Insumo no encontrado.");

            insumo.StockActual += cantidad;
            _uow.InsumoRepository.Actualizar(insumo);

       
            var movimiento = new MovimientoStock
            {
                InsumoId = insumoId,
                Fecha = DateTime.Now,
                Tipo = TipoMovimiento.Entrada,
                Cantidad = cantidad, 
                UsuarioId = usuarioId
            };
            _uow.MovimientoStockRepository.Registrar(movimiento);

           
            _bitacora.Registrar(UsuarioActual(), "Entrada Stock", $"Insumo: {insumo.Nombre}, Cant: {cantidad}");

         
            _uow.Commit();
        }

        
        public List<Insumo> GetInsumosStockCritico()
        {
            return _uow.InsumoRepository.ListarStockCritico().ToList();
        }

        public List<MovimientoStock> GetHistorialMovimientos(int insumoId, DateTime desde, DateTime hasta)
        {
            return _uow.MovimientoStockRepository.ListarPorInsumo(insumoId, desde, hasta).ToList();
        }
        public List<string> GetCategoriasInsumos()
        {
            return _uow.InsumoRepository.ListarCategorias().ToList();
        }


        public List<string> GetCategoriasProveedores()
        {
            return _uow.ProveedorRepository.ListarCategorias().ToList();
        }
        #endregion

        public void SetActivoProveedor(int proveedorId, bool activo)
        {
            var p = _uow.ProveedorRepository.ObtenerPorId(proveedorId);
            if (p == null)
                throw new Exception("El proveedor no fue encontrado.");

            if (!activo)
            {   
                var insumosActivos = _uow.InsumoRepository.ListarActivosPorProveedor(proveedorId);
                if (insumosActivos.Any())
                {
                    string insumosStr = string.Join(", ", insumosActivos.Select(i => i.Nombre).Take(3));
                    throw new Exception($"No se puede desactivar '{p.Nombre}'. Sigue asociado a insumos activos (ej: {insumosStr}).");
                }
            }
            _uow.ProveedorRepository.SetActivo(proveedorId, activo);

            string accion = activo ? "Activación Proveedor" : "Baja Proveedor";
            _bitacora.Registrar(UsuarioActual(), accion, $"Proveedor: {p.Nombre} (ID: {p.Id})");

            _uow.Commit();
        }
    }
    }
