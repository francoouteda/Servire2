using System;
using System.Collections.Generic;
using Servire.Services.Dal.Interfaces;
using Servire.Services.Domain.Composite;
using Servire.Services.Dal.Implementations; // Para llamar a los repos

namespace Servire.Services.Dal.Implementations.Adapters
{
    public sealed class FamiliaAdapter : IAdapter<Familia>
    {
        #region Singleton
        private readonly static FamiliaAdapter _instance = new FamiliaAdapter();
        public static FamiliaAdapter Current => _instance;
        private FamiliaAdapter() { }
        #endregion

        public Familia Get(object[] values)
        {
            // Asume [0]IdFamilia, [1]Nombre
            Familia familia = new Familia
            {
                Id = Guid.Parse(values[0].ToString()),
                Nombre = values[1].ToString()
            };

            // Lógica de recursividad del profesor
            var familiasHijas = new FamiliaFamiliaRepository().GetByObject(familia);
            familia.AddRange(familiasHijas);

            var patentesHijas = new FamiliaPatenteRepository().GetByObject(familia);
            familia.AddRange(patentesHijas);

            return familia;
        }
    }
}