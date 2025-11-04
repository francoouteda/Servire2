using Microsoft.Data.SqlClient; // <-- ¡Usar Microsoft!
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System.Data;

namespace Servire.Dal.Ado
{
    public class UsuarioRepositoryAdo : IUsuarioRepository
    {
        private readonly SqlTransaction _transaction;
        private SqlConnection Connection => _transaction.Connection;

        public UsuarioRepositoryAdo(SqlTransaction transaction)
        {
            _transaction = transaction;
        }

        public Usuario? ObtenerPorId(int id)
        {
            const string sql = "SELECT * FROM Usuarios WHERE Id = @id";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Mapear(reader);
            }
            return null;
        }

        public Usuario? ObtenerPorUsername(string username)
        {
            const string sql = "SELECT * FROM Usuarios WHERE Username = @username";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@username", username);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Mapear(reader);
            }
            return null;
        }

        public IEnumerable<Usuario> Listar()
        {
            const string sql = "SELECT * FROM Usuarios ORDER BY Username";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            using var reader = cmd.ExecuteReader();

            var lista = new List<Usuario>();
            while (reader.Read())
            {
                lista.Add(Mapear(reader));
            }
            return lista;
        }

        public void Crear(Usuario u)
        {
            const string sql = @"
                INSERT INTO Usuarios (Username, PasswordHash, Nombre, Dni, Rol, Activo, UltimoAcceso) 
                VALUES (@Username, @PasswordHash, @Nombre, @Dni, @Rol, @Activo, @UltimoAcceso)";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@Username", u.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", u.PasswordHash);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@Dni", u.Dni);
            cmd.Parameters.AddWithValue("@Rol", u.Rol);
            cmd.Parameters.AddWithValue("@Activo", u.Activo);
            cmd.Parameters.AddWithValue("@UltimoAcceso", u.UltimoAcceso ?? (object)DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Usuario u)
        {
            const string sql = @"
                UPDATE Usuarios SET 
                    Username = @Username, 
                    PasswordHash = @PasswordHash, 
                    Nombre = @Nombre, 
                    Dni = @Dni, 
                    Rol = @Rol, 
                    Activo = @Activo, 
                    UltimoAcceso = @UltimoAcceso
                WHERE Id = @Id";

            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@Username", u.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", u.PasswordHash);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@Dni", u.Dni);
            cmd.Parameters.AddWithValue("@Rol", u.Rol);
            cmd.Parameters.AddWithValue("@Activo", u.Activo);
            cmd.Parameters.AddWithValue("@UltimoAcceso", u.UltimoAcceso ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Id", u.Id);

            cmd.ExecuteNonQuery();
        }

        public bool ExisteUsername(string username, int idIgnorar = 0)
        {
            const string sql = "SELECT COUNT(1) FROM Usuarios WHERE Username = @username AND Id <> @idIgnorar";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@idIgnorar", idIgnorar);

            return (int)cmd.ExecuteScalar() > 0;
        }

        public bool ExisteDni(string dni, int idIgnorar = 0)
        {
            const string sql = "SELECT COUNT(1) FROM Usuarios WHERE Dni = @dni AND Id <> @idIgnorar";
            using var cmd = new SqlCommand(sql, Connection, _transaction);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@idIgnorar", idIgnorar);

            return (int)cmd.ExecuteScalar() > 0;
        }

        private static Usuario Mapear(IDataReader reader)
        {
            return new Usuario
            {
                Id = (int)reader["Id"],
                Username = (string)reader["Username"],
                PasswordHash = (string)reader["PasswordHash"],
                Nombre = (string)reader["Nombre"],
                Dni = (string)reader["Dni"],
                Rol = (Rol)reader["Rol"], // Asume que 'Rol' es un 'int' en la BD
                Activo = (bool)reader["Activo"],
                UltimoAcceso = reader["UltimoAcceso"] == DBNull.Value ? null : (DateTime?)reader["UltimoAcceso"]
            };
        }
    }
}