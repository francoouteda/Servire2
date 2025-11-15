using System;
using System.Data;
using Microsoft.Data.SqlClient; // Ojo: Usa este namespace para .NET 8
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Servire.Services.Tools
{
    internal static class SqlHelper
    {
        // Variable para guardar la cadena de conexión
        private static string conString;

        static SqlHelper()
        {
            // Truco para leer appsettings.json desde una clase estática en .NET 8
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            // CORRECCIÓN:
            // Cambiamos "MainConString" por "DefaultConnection" para que coincida
            // con tu archivo appsettings.json
            conString = configuration.GetConnectionString("DefaultConnection");
        }
        public static Int32 ExecuteNonQuery(String commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            // Validación básica de nulos
            CheckNullables(parameters);

            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static Object ExecuteScalar(String commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            CheckNullables(parameters);

            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteReader(String commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            CheckNullables(parameters);

            SqlConnection conn = new SqlConnection(conString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // CloseConnection hace que al cerrar el Reader, se cierre la conexión automáticamente
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        private static void CheckNullables(SqlParameter[] parameters)
        {
            foreach (SqlParameter item in parameters)
            {
                if (item.SqlValue == null || item.Value == null)
                {
                    item.SqlValue = DBNull.Value;
                }
            }
        }
    }
}