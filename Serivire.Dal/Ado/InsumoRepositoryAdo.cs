using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System.Collections.Generic;
using System.Data;

namespace Servire.Dal.Ado
{
    public class InsumoRepositoryAdo : IInsumoRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _connection;

        public InsumoRepositoryAdo(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        private static Insumo Mapear(IDataReader reader, bool joinProveedor = false)
        {
            var insumo = new Insumo
            {
                Id = (int)reader["Id"],
                Nombre = (string)reader["Nombre"],
                UnidadMedida = (string)reader["UnidadMedida"],
                StockActual = (decimal)reader["StockActual"],
                StockMinimo = (decimal)reader["StockMinimo"],
                Categoria = reader["Categoria"] == DBNull.Value ? string.Empty : (string)reader["Categoria"],
                ProveedorId = reader["ProveedorId"] == DBNull.Value ? 0 : (int)reader["ProveedorId"],
                EsVendible = (bool)reader["EsVendible"],
                PrecioVenta = (decimal)reader["PrecioVenta"],
                CostoUnitario = (decimal)reader["CostoUnitario"],
                Activo = (bool)reader["Activo"]
            };

            if (joinProveedor && reader["ProveedorNombre"] != DBNull.Value)
            {

                insumo.Proveedor = new Proveedor
                {
                    Id = insumo.ProveedorId,
                    Nombre = (string)reader["ProveedorNombre"]
                };
            }
            return insumo;
        }

        public Insumo? ObtenerPorId(int id)
        {
            const string sql = @"
                SELECT i.*, p.Nombre as ProveedorNombre 
                FROM Insumos i
                LEFT JOIN Proveedores p ON i.ProveedorId = p.Id
                WHERE i.Id = @id";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Mapear(reader, joinProveedor: true) : null;
        }

        public IEnumerable<Insumo> Listar()
        {
            var lista = new List<Insumo>();
            const string sql = @"
    SELECT i.*, p.Nombre as ProveedorNombre 
    FROM Insumos i
    LEFT JOIN Proveedores p ON i.ProveedorId = p.Id
    WHERE i.Activo = 1 
    ORDER BY i.Nombre";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(Mapear(reader, joinProveedor: true));
            }
            return lista;
        }
        public IEnumerable<Insumo> ListarStockCritico()
        {
            var lista = new List<Insumo>();

            const string sql = @"
    SELECT i.*, p.Nombre as ProveedorNombre 
    FROM Insumos i
    LEFT JOIN Proveedores p ON i.ProveedorId = p.Id
    WHERE i.Activo = 1 AND i.StockActual <= i.StockMinimo AND i.StockMinimo > 0 
    ORDER BY i.Nombre";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(Mapear(reader, joinProveedor: true));
            }
            return lista;
        }

        public void Crear(Insumo insumo)
        {
            const string sql = @"
                INSERT INTO Insumos (Nombre, Categoria, UnidadMedida, StockActual, StockMinimo, ProveedorId, EsVendible, PrecioVenta, CostoUnitario, Activo) 
                VALUES (@Nombre, @Categoria, @UnidadMedida, @StockActual, @StockMinimo, @ProveedorId, @EsVendible, @PrecioVenta, @CostoUnitario, 1)";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            cmd.Parameters.AddWithValue("@Nombre", insumo.Nombre);
            cmd.Parameters.AddWithValue("@Categoria", (object)insumo.Categoria ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UnidadMedida", insumo.UnidadMedida);
            cmd.Parameters.AddWithValue("@StockActual", insumo.StockActual);
            cmd.Parameters.AddWithValue("@StockMinimo", insumo.StockMinimo);
            cmd.Parameters.AddWithValue("@ProveedorId", insumo.ProveedorId > 0 ? (object)insumo.ProveedorId : DBNull.Value);
            cmd.Parameters.AddWithValue("@EsVendible", insumo.EsVendible);
            cmd.Parameters.AddWithValue("@PrecioVenta", insumo.PrecioVenta);
            cmd.Parameters.AddWithValue("@CostoUnitario", insumo.CostoUnitario);

            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Insumo insumo)
        {
            const string sql = @"
                UPDATE Insumos SET 
                    Nombre = @Nombre, 
                    Categoria = @Categoria, 
                    UnidadMedida = @UnidadMedida, 
                    StockActual = @StockActual, 
                    StockMinimo = @StockMinimo, 
                    ProveedorId = @ProveedorId,
                    EsVendible = @EsVendible,
                    PrecioVenta = @PrecioVenta,
                    CostoUnitario = @CostoUnitario,
                    Activo = @Activo
                WHERE Id = @Id";

            using var cmd = new SqlCommand(sql, Connection, _transaction);

            cmd.Parameters.AddWithValue("@Nombre", insumo.Nombre);
            cmd.Parameters.AddWithValue("@Categoria", (object)insumo.Categoria ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UnidadMedida", insumo.UnidadMedida);
            cmd.Parameters.AddWithValue("@StockActual", insumo.StockActual);
            cmd.Parameters.AddWithValue("@StockMinimo", insumo.StockMinimo);
            cmd.Parameters.AddWithValue("@ProveedorId", insumo.ProveedorId > 0 ? (object)insumo.ProveedorId : DBNull.Value);
            cmd.Parameters.AddWithValue("@EsVendible", insumo.EsVendible);
            cmd.Parameters.AddWithValue("@PrecioVenta", insumo.PrecioVenta);
            cmd.Parameters.AddWithValue("@CostoUnitario", insumo.CostoUnitario);
            cmd.Parameters.AddWithValue("@Activo", insumo.Activo);
            cmd.Parameters.AddWithValue("@Id", insumo.Id);

            cmd.ExecuteNonQuery();
        }
        public IEnumerable<Insumo> ListarActivosPorProveedor(int proveedorId)
        {
            var lista = new List<Insumo>();
            const string sql = "SELECT * FROM Insumos WHERE Activo = 1 AND ProveedorId = @proveedorId";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@proveedorId", proveedorId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(Mapear(reader, joinProveedor: false));
            }
            return lista;
        }

        public bool ExisteNombre(string nombre, int idIgnorar = 0)
        {
            const string sql = "SELECT COUNT(1) FROM Insumos WHERE Nombre = @nombre AND Id <> @idIgnorar";
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
                FROM Insumos 
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