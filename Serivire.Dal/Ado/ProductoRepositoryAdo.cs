using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System.Collections.Generic;
using System.Data;

namespace Servire.Dal.Ado
{
    public class ProductoRepositoryAdo : IProductoRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _connection;

        public ProductoRepositoryAdo(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        private static Producto Mapear(IDataReader reader)
        {
            return new Producto
            {
                Id = (int)reader["Id"],
                Nombre = (string)reader["Nombre"],
                PrecioVenta = (decimal)reader["PrecioVenta"],
                Categoria = reader["Categoria"] == DBNull.Value ? string.Empty : (string)reader["Categoria"],
                TiempoPreparacionMinutos = reader["TiempoPreparacionMinutos"] == DBNull.Value ? (int?)null : (int)reader["TiempoPreparacionMinutos"],
                Activo = (bool)reader["Activo"]
            };
        }

        public Producto? ObtenerPorId(int id)
        {
            const string sql = "SELECT * FROM Productos WHERE Id = @id";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Mapear(reader) : null;
        }

        public IEnumerable<Producto> Listar(bool incluirInactivos)
        {
            var lista = new List<Producto>();
            string sql = "SELECT * FROM Productos";

            if (!incluirInactivos)
            {
                sql += " WHERE Activo = 1";
            }

            sql += " ORDER BY Categoria, Nombre";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(Mapear(reader));
            }
            return lista;
        }

        public int Crear(Producto producto)
        {
            const string sql = @"
                INSERT INTO Productos (Nombre, PrecioVenta, Categoria, TiempoPreparacionMinutos, Activo) 
                OUTPUT INSERTED.Id
                VALUES (@Nombre, @PrecioVenta, @Categoria, @TiempoPreparacionMinutos, 1)";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            cmd.Parameters.AddWithValue("@Categoria", (object)producto.Categoria ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TiempoPreparacionMinutos", (object)producto.TiempoPreparacionMinutos ?? DBNull.Value);


            return (int)cmd.ExecuteScalar();
        }

        public void Actualizar(Producto producto)
        {
            const string sql = @"
                UPDATE Productos SET 
                    Nombre = @Nombre, 
                    PrecioVenta = @PrecioVenta, 
                    Categoria = @Categoria, 
                    TiempoPreparacionMinutos = @TiempoPreparacionMinutos
                WHERE Id = @Id";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            cmd.Parameters.AddWithValue("@Categoria", (object)producto.Categoria ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TiempoPreparacionMinutos", (object)producto.TiempoPreparacionMinutos ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Id", producto.Id);

            cmd.ExecuteNonQuery();
        }

        public void SetActivo(int productoId, bool activo)
        {
            const string sql = "UPDATE Productos SET Activo = @activo WHERE Id = @Id";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@activo", activo);
            cmd.Parameters.AddWithValue("@Id", productoId);
            cmd.ExecuteNonQuery();
        }

        public bool ExisteNombre(string nombre, int idIgnorar = 0)
        {
            const string sql = "SELECT COUNT(1) FROM Productos WHERE Nombre = @nombre AND Id <> @idIgnorar";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@idIgnorar", idIgnorar);
            return (int)cmd.ExecuteScalar() > 0;
        }

        public IEnumerable<string> ListarCategorias()
        {
            var lista = new List<string>();
            const string sql = @"
                SELECT DISTINCT Categoria 
                FROM Productos 
                WHERE Categoria IS NOT NULL AND Categoria <> ''
                ORDER BY Categoria";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add((string)reader["Categoria"]);
            }
            return lista;
        }
    }
}