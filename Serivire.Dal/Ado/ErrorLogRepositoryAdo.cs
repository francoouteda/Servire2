using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Bll.DTOs; // ¡Usa el DTO que creamos!
using System.Data;

namespace Servire.Dal.Ado
{
    public class ErrorLogRepositoryAdo : IErrorLogRepository
    {
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _transaction.Connection;

        public ErrorLogRepositoryAdo(SqlTransaction transaction)
        {
            _transaction = transaction;
        }

        public IEnumerable<ErrorLogDto> Listar(DateTime desde, DateTime hasta)
        {
            const string sql = @"
    SELECT Id, Fecha, Usuario, Nivel, Origen AS Fuente, Mensaje, StackTrace AS Stacktrace
    FROM ErrorLogs 
                WHERE Fecha BETWEEN @desde AND @hasta 
                ORDER BY Fecha DESC";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            cmd.Parameters.AddWithValue("@desde", desde.Date);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date.AddDays(1).AddTicks(-1));

            using var reader = cmd.ExecuteReader();
            var lista = new List<ErrorLogDto>();
            while (reader.Read())
            {
                lista.Add(Mapear(reader));
            }
            return lista;
        }

        private static ErrorLogDto Mapear(IDataReader reader)
        {
            return new ErrorLogDto
            {
                Id = Convert.ToInt64(reader["Id"]),
                Fecha = (DateTime)reader["Fecha"],
                Usuario = reader["Usuario"] == DBNull.Value ? "N/A" : (string)reader["Usuario"],
                Nivel = reader["Nivel"] == DBNull.Value ? "N/A" : (string)reader["Nivel"], // <-- 3. AGREGAR ESTA LÍNEA
                Fuente = reader["Fuente"] == DBNull.Value ? "N/A" : (string)reader["Fuente"],
                Mensaje = (string)reader["Mensaje"],
                Stacktrace = reader["Stacktrace"] == DBNull.Value ? "" : (string)reader["Stacktrace"]
            };
        }
    }
}