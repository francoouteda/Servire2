using System.Collections.Generic;
using System; // Para Guid

namespace Servire.Services.Domain.Composite
{
    public abstract class PermisoComponente
    {
        // El ID debe ser Guid para coincidir con la BD del profesor
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Permiso { get; set; } // Lo usaremos para la clave (DataKey)

        public abstract IList<PermisoComponente> Hijos { get; }
        public abstract void AgregarHijo(PermisoComponente c);
        public abstract void VaciarHijos();

        public override string ToString() => Nombre;
    }
}