using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servire.Domain.Entities
{
    public class DetalleReceta
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int InsumoId { get; set; }
        public decimal Cantidad { get; set; }
    }
}
