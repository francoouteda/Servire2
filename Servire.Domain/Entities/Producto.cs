using System.Collections.Generic;

namespace Servire.Domain.Entities
{
    
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int? TiempoPreparacionMinutos { get; set; }

        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

        public bool Activo { get; set; } = true;
    }
}