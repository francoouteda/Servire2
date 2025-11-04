using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System.Data;

namespace Servire.Dal.Ado
{
    public class BitacoraRepositoryAdo : IBitacoraRepository
    {
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _transaction.Connection;

        public BitacoraRepositoryAdo(SqlTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Registrar(Bitacora bitacora)
        {
            // --- CAMBIO 1: Nombres de columna en el SQL ---
            const string sql = "INSERT INTO Bitacora (Fecha, Usuario, Accion, Detalle) VALUES (@fecha, @user, @accion, @msg)";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            // Los parámetros (@user, @msg) están bien, 
            // solo mapeamos las propiedades de la entidad a ellos.
            cmd.Parameters.AddWithValue("@fecha", bitacora.Fecha);
            cmd.Parameters.AddWithValue("@user", bitacora.Username); // La entidad tiene Username
            cmd.Parameters.AddWithValue("@accion", bitacora.Accion);
            cmd.Parameters.AddWithValue("@msg", bitacora.Mensaje);   // La entidad tiene Mensaje

            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Bitacora> Listar(DateTime desde, DateTime hasta)
        {
            // --- CAMBIO 2: Nombres de columna en el SQL ---
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
                // --- LA CORRECCIÓN ESTÁ AQUÍ ---
                // Usamos Convert.ToInt32() en lugar de (int)
                // Esto sabe cómo manejar la conversión de Int64 a Int32
                Id = Convert.ToInt32(reader["Id"]),

                Fecha = (DateTime)reader["Fecha"],
                Username = (string)reader["Usuario"], // Mapea la columna "Usuario" a la propiedad "Username"
                Accion = (string)reader["Accion"],
                Mensaje = (string)reader["Detalle"]  // Mapea la columna "Detalle" a la propiedad "Mensaje"
            };
        }
    }
    }
