using System;
using Servire.Services.Dal.Interfaces;
using Servire.Services.Domain.Composite;

namespace Servire.Services.Dal.Implementations.Adapters
{
    public sealed class PatenteAdapter : IAdapter<Patente>
    {
        #region Singleton
        private readonly static PatenteAdapter _instance = new PatenteAdapter();
        public static PatenteAdapter Current => _instance;
        private PatenteAdapter() { }
        #endregion

        public Patente Get(object[] values)
        {
            // Asume [0]IdPatente, [1]Permiso (DataKey)
            return new Patente
            {
                Id = Guid.Parse(values[0].ToString()),
                Permiso = values[1].ToString(),
                Nombre = values[1].ToString() // El profe usa DataKey, nosotros usamos Permiso y Nombre
            };
        }
    }
}