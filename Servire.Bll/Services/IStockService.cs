using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Servire.Bll.Services 
{
    public interface IStockService
    {
        

        IUnitOfWork GetUoW();
        List<Insumo> GetInsumos();
        Insumo GetInsumo(int id);
        void GuardarInsumo(Insumo insumo); 

        List<Proveedor> GetProveedores(bool incluirInactivos = false);
        void GuardarProveedor(Proveedor proveedor); 

        void RegistrarEntrada(int insumoId, decimal cantidad, int usuarioId, string? nroFactura = null);

        List<Insumo> GetInsumosStockCritico();
        List<MovimientoStock> GetHistorialMovimientos(int insumoId, DateTime desde, DateTime hasta);

        List<string> GetCategoriasInsumos();

        List<string> GetCategoriasProveedores();

        void SetActivoProveedor(int proveedorId, bool activo);
    }
}