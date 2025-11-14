using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System.Collections.Generic;
using System.Data;

namespace Servire.Dal.Ado
{
    public class ProveedorRepositoryAdo : IProveedorRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _connection;

        public ProveedorRepositoryAdo(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        private static Proveedor Mapear(IDataReader reader)
        {
            return new Proveedor
            {
                Id = (int)reader["Id"],
                Nombre = (string)reader["Nombre"],
                Categoria = reader["Categoria"] == DBNull.Value ? string.Empty : (string)reader["Categoria"],
                Contacto = reader["Contacto"] == DBNull.Value ? string.Empty : (string)reader["Contacto"],
                Activo = (bool)reader["Activo"]
            };
        }

        public Proveedor? ObtenerPorId(int id)
        {
            const string sql = "SELECT * FROM Proveedores WHERE Id = @id";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Mapear(reader) : null;
        }

        public IEnumerable<Proveedor> Listar(bool incluirInactivos)
        {
            var lista = new List<Proveedor>();
            string sql = "SELECT * FROM Proveedores";

            if (!incluirInactivos)
            {
                sql += " WHERE Activo = 1";
            }

            sql += " ORDER BY Nombre";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(Mapear(reader));
            }
            return lista;
        }

        public void Crear(Proveedor proveedor)
        {
            const string sql = "INSERT INTO Proveedores (Nombre, Categoria, Contacto, Activo) VALUES (@Nombre, @Categoria, @Contacto, 1)";
            using var cmd = new SqlCommand(sql, Connection, _transaction);

            cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@Categoria", (object)proveedor.Categoria ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Contacto", (object)proveedor.Contacto ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Proveedor proveedor)
        {
            const string sql = "UPDATE Proveedores SET Nombre = @Nombre, Categoria = @Categoria, Contacto = @Contacto WHERE Id = @Id";
            using var cmd = new SqlCommand(sql, Connection, _transaction);

            cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@Categoria", (object)proveedor.Categoria ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Contacto", (object)proveedor.Contacto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Id", proveedor.Id);

            cmd.ExecuteNonQuery();
        }
        public IEnumerable<string> ListarCategorias()
        {
            var lista = new List<string>();
            const string sql = @"
        SELECT DISTINCT Categoria 
        FROM Proveedores 
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
        public void SetActivo(int proveedorId, bool activo)
        {
            const string sql = "UPDATE Proveedores SET Activo = @activo WHERE Id = @Id";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@activo", activo);
            cmd.Parameters.AddWithValue("@Id", proveedorId);
            cmd.ExecuteNonQuery();
        }
    }
}