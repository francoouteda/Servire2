namespace Servire.Domain.Entities
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UnidadMedida { get; set; } = string.Empty;
        public decimal StockActual { get; set; }
        public decimal StockMinimo { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

        public bool EsVendible { get; set; }
        public decimal PrecioVenta { get; set; }

        public decimal CostoUnitario { get; set; }
        public bool Activo { get; set; } = true;

    }
}