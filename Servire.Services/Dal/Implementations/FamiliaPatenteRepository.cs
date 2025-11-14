using Servire.Services.Dal.Interfaces;
using Servire.Services.Domain.Composite;
using Servire.Services.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Servire.Services.Dal.Implementations
{
    internal class FamiliaPatenteRepository : IJoinRepository<Patente, Familia>
    {
        public List<Patente> GetByObject(Familia obj)
        {
            List<Patente> patentes = new List<Patente>();
            string sql = "SELECT IdPatente FROM FamiliaPatente WHERE IdFamilia = @IdFamilia";

            using (var reader = SqlHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@IdFamilia", obj.Id)))
            {
                while (reader.Read())
                {
                    Guid idPatente = reader.GetGuid(0); // Usa GetGuid
                    patentes.Add(new PatenteRepository().GetById(idPatente));
                }
            }
            return patentes;
        }
    }
}