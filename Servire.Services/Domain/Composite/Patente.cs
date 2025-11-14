using System;
using System.Collections.Generic;

namespace Servire.Services.Domain.Composite
{
    public class Patente : PermisoComponente
    {
        public override IList<PermisoComponente> Hijos => new List<PermisoComponente>();

        public override void AgregarHijo(PermisoComponente c)
        {
            throw new InvalidOperationException("No se pueden agregar hijos a una Patente.");
        }

        public override void VaciarHijos() { }
    }
}