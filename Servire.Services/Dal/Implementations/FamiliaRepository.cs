using Servire.Services.Dal.Implementations.Adapters;
using Servire.Services.Dal.Interfaces;
using Servire.Services.Domain.Composite;
using Servire.Services.Tools;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Servire.Services.Dal.Implementations
{
    internal class FamiliaRepository : IFamiliaRepository
    {
        // Acepta Guid
        public Familia GetById(Guid id)
        {
            string sql = "SELECT IdFamilia, Nombre FROM Familia WHERE IdFamilia = @Id";

            using (var reader = SqlHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    return FamiliaAdapter.Current.Get(values);
                }
            }
            return null;
        }
    }
}