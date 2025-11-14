namespace Servire.Domain.Entities
{
 
    public class Ingrediente
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int InsumoId { get; set; }
        public decimal Cantidad { get; set; }
        public Insumo? Insumo { get; set; }
    }
}