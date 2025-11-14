using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Servire.Dal.Ado
{
    public class IngredienteRepositoryAdo : IIngredienteRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _connection;

        public IngredienteRepositoryAdo(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        private static Ingrediente Mapear(IDataReader reader)
        {
            var ingrediente = new Ingrediente
            {
                Id = (int)reader["Id"],
                ProductoId = (int)reader["ProductoId"],
                InsumoId = (int)reader["InsumoId"],
                Cantidad = (decimal)reader["Cantidad"]
            };

            if (reader.GetSchemaTable().Columns.Contains("InsumoNombre"))
            {
                ingrediente.Insumo = new Insumo
                {
                    Id = (int)reader["InsumoId"],
                    Nombre = (string)reader["InsumoNombre"],
                    UnidadMedida = (string)reader["InsumoUnidad"]
                };
            }
            return ingrediente;
        }

        public IEnumerable<Ingrediente> ObtenerPorProducto(int productoId)
        {
            var lista = new List<Ingrediente>();
            const string sql = @"
                SELECT ing.*, i.Nombre as InsumoNombre, i.UnidadMedida as InsumoUnidad
                FROM Ingredientes ing
                JOIN Insumos i ON ing.InsumoId = i.Id
                WHERE ing.ProductoId = @ProductoId";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@ProductoId", productoId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(Mapear(reader));
            }
            return lista;
        }

        public void SincronizarReceta(int productoId, List<Ingrediente> ingredientes)
        {

            const string sqlDelete = "DELETE FROM Ingredientes WHERE ProductoId = @ProductoId";
            using (var cmdDelete = new SqlCommand(sqlDelete, Connection, _transaction))
            {
                cmdDelete.Parameters.AddWithValue("@ProductoId", productoId);
                cmdDelete.ExecuteNonQuery();
            }


            if (ingredientes == null || ingredientes.Count == 0) return;


            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Ingredientes (ProductoId, InsumoId, Cantidad) VALUES ");

            var parameters = new List<SqlParameter>();
            for (int i = 0; i < ingredientes.Count; i++)
            {
                var pId = $"@pId{i}";
                var pCant = $"@pCant{i}";

                sb.Append($"(@ProductoId, {pId}, {pCant})");
                if (i < ingredientes.Count - 1) sb.Append(",");

                parameters.Add(new SqlParameter(pId, ingredientes[i].InsumoId));
                parameters.Add(new SqlParameter(pCant, ingredientes[i].Cantidad));
            }

            using (var cmdInsert = new SqlCommand(sb.ToString(), Connection, _transaction))
            {
                cmdInsert.Parameters.AddWithValue("@ProductoId", productoId);
                cmdInsert.Parameters.AddRange(parameters.ToArray());
                cmdInsert.ExecuteNonQuery();
            }
        }
    }
}