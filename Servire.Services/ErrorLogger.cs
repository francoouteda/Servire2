using Servire.Bll.Interfaces;
using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration; // <-- 1. Añadir using
using Microsoft.Data.SqlClient;          // <-- 2. Añadir using

namespace Servire.Services
{
    public class ErrorLogger : IErrorLogger
    {
        private readonly string _errorLogFilePath;
        private readonly string _infoLogFilePath;
        private static readonly object _lock = new object();

        // --- 3. Añadir campo para la conexión ---
        private readonly string _connectionString;

        // --- 4. Modificar el constructor ---
        public ErrorLogger(IConfiguration configuration)
        {
            // Define las rutas para los archivos de log
            string baseDir = AppContext.BaseDirectory;
            string logDir = Path.Combine(baseDir, "logs");
            Directory.CreateDirectory(logDir);

            _errorLogFilePath = Path.Combine(logDir, "servire_errors.log");
            _infoLogFilePath = Path.Combine(logDir, "servire_info.log");

            // --- 5. Obtener la cadena de conexión ---
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new ArgumentNullException("DefaultConnection");
        }

        public void Info(string origen, string mensaje, string? usuario = null)
        {
            // (El método Info no lo modificamos, solo escribe en el archivo)
            try
            {
                var entry = new StringBuilder();
                entry.AppendLine($"========== INFO ==========");
                entry.AppendLine($"Fecha:    {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                entry.AppendLine($"Usuario:  {usuario ?? "N/A"}");
                entry.AppendLine($"Fuente:   {origen}");
                entry.AppendLine($"Mensaje:  {mensaje}");
                entry.AppendLine("-------------------------------------------------");
                entry.AppendLine();

                lock (_lock)
                {
                    File.AppendAllText(_infoLogFilePath, entry.ToString());
                }
            }
            catch (Exception) { /* Si el logger falla, no podemos hacer nada. */ }
        }

        public void Error(string origen, Exception ex, string? usuario = null)
        {
            // --- 6. Llamar a ambos métodos ---
            LogErrorToFile(origen, ex, usuario);
            LogErrorToDatabase(origen, ex, usuario);
        }

        // --- 7. Mover la lógica de archivo a su propio método ---
        private void LogErrorToFile(string origen, Exception ex, string? usuario = null)
        {
            try
            {
                var entry = new StringBuilder();
                entry.AppendLine($"========== ERROR ==========");
                entry.AppendLine($"Fecha:    {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                entry.AppendLine($"Usuario:  {usuario ?? "N/A"}");
                entry.AppendLine($"Fuente:   {origen}");
                entry.AppendLine($"Mensaje:  {ex.Message}");
                entry.AppendLine($"Stacktrace:");
                entry.AppendLine(ex.StackTrace);
                entry.AppendLine("-------------------------------------------------");
                entry.AppendLine();

                lock (_lock)
                {
                    File.AppendAllText(_errorLogFilePath, entry.ToString());
                }
            }
            catch (Exception) { /* Si el logger de archivos falla, no podemos hacer nada. */ }
        }

        // --- 8. Añadir nuevo método para escribir en la BD ---
        private void LogErrorToDatabase(string origen, Exception ex, string? usuario = null)
        {
            // Un logger NUNCA debe fallar. Si falla el log, lo ignoramos.
            try
            {
                // Usamos una conexión INDEPENDIENTE.
                // NO usamos IUnitOfWork aquí para evitar dependencias circulares.
                using var conn = new SqlConnection(_connectionString);
                const string sql = @"
                    INSERT INTO ErrorLogs (Fecha, Usuario, Fuente, Mensaje, Stacktrace) 
                    VALUES (@Fecha, @Usuario, @Fuente, @Mensaje, @Stacktrace)";

                using var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@Usuario", (object)usuario ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Fuente", (object)origen ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Mensaje", ex.Message);
                cmd.Parameters.AddWithValue("@Stacktrace", (object)ex.StackTrace ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Si falla el log a la BD, no hacemos nada (el log a archivo debería funcionar).
            }
        }
    }
}