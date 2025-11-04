using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servire.Domain.Entities;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }     // p.ej. 18,2
    public string Categoria { get; set; } = ""; // "Plato", "Bebida", etc.
}
