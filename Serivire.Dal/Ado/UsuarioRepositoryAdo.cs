using Microsoft.Data.SqlClient;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using Servire.Domain.Entities.Seguridad;
using System.Data;

namespace Servire.Dal.Ado
{
    public class UsuarioRepositoryAdo : IUsuarioRepository
    {
        
        private readonly SqlConnection _conn;
        private readonly SqlTransaction _tx;

       
        public UsuarioRepositoryAdo(SqlConnection conn, SqlTransaction tx)
        {
            _conn = conn;
            _tx = tx;
        }

        public void Crear(Usuario u)
        {
            string sql = @"INSERT INTO Usuarios (
                                Username, PasswordHash, Nombre, Dni, Rol, Activo, 
                                UltimoAcceso, IdiomaPreferido
                           ) VALUES (
                                @Username, @PasswordHash, @Nombre, @Dni, @Rol, @Activo, 
                                @UltimoAcceso, @IdiomaPreferido
                           );
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

      
            using var cmd = new SqlCommand(sql, _conn, _tx);

            cmd.Parameters.AddWithValue("@Username", u.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", u.PasswordHash);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@Dni", u.Dni);
            cmd.Parameters.AddWithValue("@Rol", u.Rol);
            cmd.Parameters.AddWithValue("@Activo", u.Activo);
            cmd.Parameters.AddWithValue("@UltimoAcceso", u.UltimoAcceso);
            cmd.Parameters.AddWithValue("@IdiomaPreferido", (object)u.IdiomaPreferido ?? DBNull.Value);

            u.Id = (int)cmd.ExecuteScalar();
        }

        public void Actualizar(Usuario u)
        {
            string sql = @"UPDATE Usuarios SET 
                                Username = @Username, 
                                Nombre = @Nombre, 
                                Dni = @Dni, 
                                Rol = @Rol, 
                                Activo = @Activo,
                                UltimoAcceso = @UltimoAcceso,
                                IdiomaPreferido = @IdiomaPreferido
                           WHERE Id = @Id";

       
            using var cmd = new SqlCommand(sql, _conn, _tx);

            cmd.Parameters.AddWithValue("@Username", u.Username);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@Dni", u.Dni);
            cmd.Parameters.AddWithValue("@Rol", (int)u.Rol);
            cmd.Parameters.AddWithValue("@Activo", u.Activo);
            cmd.Parameters.AddWithValue("@UltimoAcceso", u.UltimoAcceso);
            cmd.Parameters.AddWithValue("@IdiomaPreferido", (object)u.IdiomaPreferido ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Id", u.Id);

            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Usuario> Listar()
        {
            var lista = new List<Usuario>();
            string sql = @"SELECT Id, Username, PasswordHash, Nombre, Dni, Rol, 
                                  Activo, UltimoAcceso, IdiomaPreferido 
                           FROM Usuarios";


            using var cmd = new SqlCommand(sql, _conn, _tx);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(Mapper(reader));
            }
            return lista;
        }

        public Usuario? ObtenerPorId(int id)
        {
            string sql = @"SELECT Id, Username, PasswordHash, Nombre, Dni, Rol, 
                                  Activo, UltimoAcceso, IdiomaPreferido 
                           FROM Usuarios WHERE Id = @Id";

            using var cmd = new SqlCommand(sql, _conn, _tx);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Mapper(reader);
            }
            return null;
        }

        public Usuario? ObtenerPorUsername(string username)
        {
            string sql = @"SELECT Id, Username, PasswordHash, Nombre, Dni, Rol, 
                          Activo, UltimoAcceso, IdiomaPreferido 
                   FROM Usuarios
                   WHERE UPPER(Username) = UPPER(@Username)";

            
            using var cmd = new SqlCommand(sql, _conn, _tx);
            cmd.Parameters.AddWithValue("@Username", username);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Mapper(reader);
            }
            return null;
        }

        
        public bool ExisteUsername(string username, int idIgnorar = 0)
        {
            string sql = "SELECT COUNT(1) FROM Usuarios WHERE Username = @Username";
            if (idIgnorar > 0)
            {
                sql += " AND Id != @Id";
            }

            
            using var cmd = new SqlCommand(sql, _conn, _tx);
            cmd.Parameters.AddWithValue("@Username", username);
            if (idIgnorar > 0)
            {
                cmd.Parameters.AddWithValue("@Id", idIgnorar);
            }

            return (int)cmd.ExecuteScalar() > 0;
        }

        
        public bool ExisteDni(string dni, int idIgnorar = 0)
        {
            string sql = "SELECT COUNT(1) FROM Usuarios WHERE Dni = @Dni";
            if (idIgnorar > 0)
            {
                sql += " AND Id != @Id";
            }

            
            using var cmd = new SqlCommand(sql, _conn, _tx);
            cmd.Parameters.AddWithValue("@Dni", dni);
            if (idIgnorar > 0)
            {
                cmd.Parameters.AddWithValue("@Id", idIgnorar);
            }

            return (int)cmd.ExecuteScalar() > 0;
        }

        private Usuario Mapper(SqlDataReader reader)
        {
            return new Usuario
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Username = reader.GetString(reader.GetOrdinal("Username")),
                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Dni = reader.GetString(reader.GetOrdinal("Dni")),
                Rol = (Rol)reader.GetInt32(reader.GetOrdinal("Rol")),
                Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),

               
                UltimoAcceso = reader.IsDBNull(reader.GetOrdinal("UltimoAcceso"))
                                 ? (DateTime?)null
                                 : reader.GetDateTime(reader.GetOrdinal("UltimoAcceso")),

                
                IdiomaPreferido = reader.IsDBNull(reader.GetOrdinal("IdiomaPreferido"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("IdiomaPreferido"))
            };
        }
    }
    }
