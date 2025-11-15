
using System;

namespace Servire.Domain.Entities
{
    // Corresponde a la entidad 'MovimientosStock' de tu Diagrama de Dominio

    public enum TipoMovimiento
    {
        Entrada = 1, // Req. Stock 001
        Salida = 2,  // Req. Stock 003 (Venta)
        Ajuste = 3   // (Para correcciones manuales)
    }

    public class MovimientoStock
    {
        public int Id { get; set; }
        public int InsumoId { get; set; }
        public Insumo? Insumo { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimiento Tipo { get; set; }
        public decimal Cantidad { get; set; } // Positivo para Entradas, Negativo para Salidas
        public int? UsuarioId { get; set; } // Quién hizo el movimiento

        // CORRECCIÓN:
        // Eliminamos esta propiedad. La entidad de negocio 'MovimientoStock'
        // no debe tener una dependencia directa a la entidad de seguridad 'Usuario'.
        // Con el 'UsuarioId' es suficiente.
        // public Usuario? Usuario { get; set; } // <- ELIMINAR ESTA LÍNEA
    }
}