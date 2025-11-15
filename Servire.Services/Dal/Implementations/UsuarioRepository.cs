using Microsoft.Data.SqlClient; // Usando el paquete que indicaste
using Servire.Services.Dal.Implementations.Adapters;
using Servire.Services.Dal.Interfaces;
 // Cambiado de Tools
using Servire.Services.Domain.Composite;
using Servire.Services.Tools;
using System;
using System.Collections.Generic;
using System.Data;

namespace Servire.Services.Dal.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // Define la lista de campos para reutilizar en todas las consultas SELECT
        private const string CAMPOS_USUARIO = @"
            IdUsuario, Username, Nombre, Email, Dni, 
            PasswordHash, Habilitado, Rol, UltimoAcceso, IdiomaPreferido";

        public Usuario GetByCredentials(string username, string passwordHash)
        {
            string sql = $@"SELECT {CAMPOS_USUARIO} 
                            FROM Usuario 
                            WHERE Username = @Username AND PasswordHash = @PasswordHash";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text,
                new SqlParameter("@Username", username),
                new SqlParameter("@PasswordHash", passwordHash)))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    return UsuarioAdapter.Current.Get(data);
                }
                return null;
            }
        }

        public Usuario ObtenerPorId(Guid id)
        {
            string sql = $@"SELECT {CAMPOS_USUARIO} 
                            FROM Usuario 
                            WHERE IdUsuario = @Id";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text,
                new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    return UsuarioAdapter.Current.Get(data);
                }
                return null;
            }
        }

        public Usuario ObtenerPorUsername(string username)
        {
            string sql = $@"SELECT {CAMPOS_USUARIO} 
                            FROM Usuario 
                            WHERE Username = @Username";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text,
                new SqlParameter("@Username", username)))
            {
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    return UsuarioAdapter.Current.Get(data);
                }
                return null;
            }
        }

        public IEnumerable<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string sql = $@"SELECT {CAMPOS_USUARIO} FROM Usuario";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    usuarios.Add(UsuarioAdapter.Current.Get(data));
                }
            }
            return usuarios;
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            usuario.IdUsuario = Guid.NewGuid();
            string sql = @"INSERT INTO Usuario (
                                IdUsuario, Username, Nombre, Email, Dni, 
                                PasswordHash, Habilitado, Rol, UltimoAcceso, IdiomaPreferido
                           ) VALUES (
                                @Id, @Username, @Nombre, @Email, @Dni, 
                                @PasswordHash, @Habilitado, @Rol, @UltimoAcceso, @IdiomaPreferido
                           )";

            SqlHelper.ExecuteNonQuery(sql, CommandType.Text,
                new SqlParameter("@Id", usuario.IdUsuario),
                new SqlParameter("@Username", usuario.Username),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Dni", usuario.Dni),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@Habilitado", usuario.Habilitado),
                new SqlParameter("@Rol", (int)usuario.Rol),
                new SqlParameter("@UltimoAcceso", (object)usuario.UltimoAcceso ?? DBNull.Value),
                new SqlParameter("@IdiomaPreferido", (object)usuario.IdiomaPreferido ?? DBNull.Value)
            );
        }

        public void Actualizar(Usuario usuario)
        {
            string sql = @"UPDATE Usuario SET 
                                Username = @Username, 
                                Nombre = @Nombre, 
                                Email = @Email, 
                                Dni = @Dni, 
                                PasswordHash = @PasswordHash, 
                                Habilitado = @Habilitado, 
                                Rol = @Rol, 
                                UltimoAcceso = @UltimoAcceso, 
                                IdiomaPreferido = @IdiomaPreferido
                           WHERE IdUsuario = @Id";

            SqlHelper.ExecuteNonQuery(sql, CommandType.Text,
                new SqlParameter("@Username", usuario.Username),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Dni", usuario.Dni),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@Habilitado", usuario.Habilitado),
                new SqlParameter("@Rol", (int)usuario.Rol),
                new SqlParameter("@UltimoAcceso", (object)usuario.UltimoAcceso ?? DBNull.Value),
                new SqlParameter("@IdiomaPreferido", (object)usuario.IdiomaPreferido ?? DBNull.Value),
                new SqlParameter("@Id", usuario.IdUsuario)
            );
        }

        public bool ExisteUsername(string username, Guid? excludeId = null)
        {
            string sql = "SELECT COUNT(1) FROM Usuario WHERE Username = @Username";
            var parameters = new List<SqlParameter> { new SqlParameter("@Username", username) };

            if (excludeId.HasValue)
            {
                sql += " AND IdUsuario != @ExcludeId";
                parameters.Add(new SqlParameter("@ExcludeId", excludeId.Value));
            }

            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, parameters.ToArray()) > 0;
        }

        public bool ExisteDni(string dni, Guid? excludeId = null)
        {
            string sql = "SELECT COUNT(1) FROM Usuario WHERE Dni = @Dni";
            var parameters = new List<SqlParameter> { new SqlParameter("@Dni", dni) };

            if (excludeId.HasValue)
            {
                sql += " AND IdUsuario != @ExcludeId";
                parameters.Add(new SqlParameter("@ExcludeId", excludeId.Value));
            }

            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, parameters.ToArray()) > 0;
        }
    }
}