using Servire.Services.Dal.Implementations.Adapters;
using Servire.Services.Dal.Interfaces;
using Servire.Services.Domain.Composite;
using Servire.Services.Tools;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Servire.Services.Dal.Implementations
{
    public class PatenteRepository : IPatenteRepository
    {
        // Acepta Guid
        public Patente GetById(Guid id)
        {
            string sql = "SELECT IdPatente, Permiso FROM Patente WHERE IdPatente = @Id";

            using (var reader = SqlHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    return PatenteAdapter.Current.Get(values);
                }
            }
            return null;
        }
    }
}