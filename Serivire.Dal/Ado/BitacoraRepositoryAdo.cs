using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System.Data;

namespace Servire.Dal.Ado
{
    public class BitacoraRepositoryAdo : IBitacoraRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _connection;

        public BitacoraRepositoryAdo(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public void Registrar(Bitacora bitacora)
        {
            const string sql = "INSERT INTO Bitacora (Fecha, Usuario, Accion, Detalle) VALUES (@fecha, @user, @accion, @msg)";

            using var cmd = new SqlCommand(sql, Connection, _transaction);


            cmd.Parameters.AddWithValue("@fecha", bitacora.Fecha);
            cmd.Parameters.AddWithValue("@user", bitacora.Username);
            cmd.Parameters.AddWithValue("@accion", bitacora.Accion);
            cmd.Parameters.AddWithValue("@msg", bitacora.Mensaje);

            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Bitacora> Listar(DateTime desde, DateTime hasta)
        {
            const string sql = "SELECT Id, Fecha, Usuario, Accion, Detalle FROM Bitacora WHERE Fecha BETWEEN @desde AND @hasta ORDER BY Fecha DESC";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta.AddDays(1).AddTicks(-1));

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return Mapear(reader);
            }
        }

        private static Bitacora Mapear(IDataReader reader)
        {
            return new Bitacora
            {
                Id = Convert.ToInt32(reader["Id"]),
                Fecha = (DateTime)reader["Fecha"],
                Username = (string)reader["Usuario"],
                Accion = (string)reader["Accion"],
                Mensaje = (string)reader["Detalle"]
            };
        }
    }
}