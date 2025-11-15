using Servire.Services.Dal.Interfaces;
using Servire.Services.Domain.Composite;
using Servire.Services.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Servire.Services.Dal.Implementations
{
    public class FamiliaFamiliaRepository : IJoinRepository<Familia, Familia>
    {
        public List<Familia> GetByObject(Familia obj)
        {
            List<Familia> familias = new List<Familia>();
            string sql = "SELECT IdFamiliaHijo FROM FamiliaFamilia WHERE IdFamiliaPadre = @IdFamiliaPadre";

            using (var reader = SqlHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@IdFamiliaPadre", obj.Id)))
            {
                while (reader.Read())
                {
                    Guid idHijo = reader.GetGuid(0); // Usa GetGuid
                    familias.Add(new FamiliaRepository().GetById(idHijo));
                }
            }
            return familias;
        }
    }
}