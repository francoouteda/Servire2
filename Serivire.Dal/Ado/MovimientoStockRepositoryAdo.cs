using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Servire.Dal.Ado
{
    public class MovimientoStockRepositoryAdo : IMovimientoStockRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _connection;

        public MovimientoStockRepositoryAdo(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        private static MovimientoStock Mapear(IDataReader reader)
        {
            return new MovimientoStock
            {
                Id = (int)reader["Id"],
                InsumoId = (int)reader["InsumoId"],
                Fecha = (DateTime)reader["Fecha"],
                Tipo = (TipoMovimiento)reader["Tipo"],
                Cantidad = (decimal)reader["Cantidad"],
                UsuarioId = reader["UsuarioId"] == DBNull.Value ? (int?)null : (int)reader["UsuarioId"]
            };
        }

        public void Registrar(MovimientoStock movimiento)
        {
            const string sql = @"
                INSERT INTO MovimientosStock (InsumoId, Fecha, Tipo, Cantidad, UsuarioId) 
                VALUES (@InsumoId, @Fecha, @Tipo, @Cantidad, @UsuarioId)";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            cmd.Parameters.AddWithValue("@InsumoId", movimiento.InsumoId);
            cmd.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
            cmd.Parameters.AddWithValue("@Tipo", movimiento.Tipo);
            cmd.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
            cmd.Parameters.AddWithValue("@UsuarioId", (object)movimiento.UsuarioId ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        public IEnumerable<MovimientoStock> ListarPorInsumo(int insumoId, DateTime desde, DateTime hasta)
        {
            var lista = new List<MovimientoStock>();
            const string sql = @"
                SELECT * FROM MovimientosStock 
                WHERE InsumoId = @InsumoId AND Fecha BETWEEN @desde AND @hasta
                ORDER BY Fecha DESC";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            cmd.Parameters.AddWithValue("@InsumoId", insumoId);
            cmd.Parameters.AddWithValue("@desde", desde.Date);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date.AddDays(1).AddTicks(-1));

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(Mapear(reader));
            }
            return lista;
        }
    }
}