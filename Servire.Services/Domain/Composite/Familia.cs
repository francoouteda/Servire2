using System.Collections.Generic;

namespace Servire.Services.Domain.Composite
{
    public class Familia : PermisoComponente
    {
        // Ya inicializamos la lista aquí
        private readonly IList<PermisoComponente> _hijos = new List<PermisoComponente>();

        public override IList<PermisoComponente> Hijos => _hijos;

        public override void AgregarHijo(PermisoComponente c)
        {
            if (!_hijos.Contains(c))
            {
                _hijos.Add(c);
            }
        }

        public void AddRange(IEnumerable<PermisoComponente> components)
        {
            foreach (var c in components)
            {
                AgregarHijo(c);
            }
        }

        public override void VaciarHijos()
        {
            _hijos.Clear();
        }
    }
}