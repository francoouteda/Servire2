using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servire.Domain.Entities
{

    public enum Rol { Admin = 1, Mozo = 2, Cocina = 3, Barra = 4 }

    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Dni { get; set; } = "";   
        public Rol Rol { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime? UltimoAcceso { get; set; }
    }
}