using Microsoft.Data.SqlClient;
using Servire.Services.Interfaces;
using Servire.Services.Domain.Logging;
using Servire.Services.Tools; // Donde pusiste el SqlHelper
using System;
using System.Data;
using System.IO;

namespace Servire.Services.Implementations
{
    public class LoggerService : ILogger
    {
        private readonly string _logFilePath;

        public LoggerService()
        {
            // Configuración de ruta de archivo (puedes sacarlo de config si quieres)
            string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
            _logFilePath = Path.Combine(logDir, $"app_{DateTime.Now:yyyyMMdd}.log");
        }

        public void Info(string mensaje, string origen, string usuario = null)
        {
            var log = new LogEntry
            {
                Mensaje = mensaje,
                Nivel = "INFO",
                Origen = origen,
                Usuario = usuario
            };
            WriteLog(log);
        }

        public void Error(Exception ex, string origen, string usuario = null)
        {
            var log = new LogEntry
            {
                Mensaje = ex.Message,
                Nivel = "ERROR",
                Origen = origen,
                Usuario = usuario,
                StackTrace = ex.StackTrace
            };
            WriteLog(log);
        }

        public void Log(string mensaje, string nivel = "INFO")
        {
            // Método genérico simple
            WriteLog(new LogEntry { Mensaje = mensaje, Nivel = nivel });
        }

        private void WriteLog(LogEntry log)
        {
            // 1. Escribir en Archivo
            try
            {
                string linea = $"{log.Fecha:yyyy-MM-dd HH:mm:ss} [{log.Nivel}] {log.Usuario ?? "N/A"} - {log.Mensaje}";
                File.AppendAllText(_logFilePath, linea + Environment.NewLine);
            }
            catch { /* No podemos hacer nada si falla el log de archivo */ }

            // 2. Escribir en Base de Datos (Usando SqlHelper)
            try
            {
                string query = @"INSERT INTO ErrorLogs (Fecha, Usuario, Nivel, Origen, Mensaje, StackTrace) 
                                 VALUES (@Fecha, @Usuario, @Nivel, @Origen, @Mensaje, @StackTrace)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Fecha", log.Fecha),
                    new SqlParameter("@Usuario", (object)log.Usuario ?? DBNull.Value),
                    new SqlParameter("@Nivel", log.Nivel),
                    new SqlParameter("@Origen", (object)log.Origen ?? DBNull.Value),
                    new SqlParameter("@Mensaje", log.Mensaje),
                    new SqlParameter("@StackTrace", (object)log.StackTrace ?? DBNull.Value)
                };

                SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                // Si falla la BD, al menos quedó en el archivo.
                // Opcional: Escribir el error de BD en el archivo.
            }
        }
        public List<LogEntry> Listar(DateTime desde, DateTime hasta, string usuario)
        {
            var lista = new List<LogEntry>();

            // Construimos la consulta base
            string query = @"SELECT Id, Fecha, Usuario, Nivel, Origen, Mensaje, StackTrace 
                             FROM ErrorLogs 
                             WHERE Fecha BETWEEN @Desde AND @Hasta";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Desde", desde.Date), // Solo la fecha
                new SqlParameter("@Hasta", hasta.Date.AddDays(1).AddSeconds(-1)) // Incluye todo el día 'hasta'
            };

            // Agregamos el filtro de usuario si no está vacío
            if (!string.IsNullOrWhiteSpace(usuario))
            {
                query += " AND Usuario LIKE @Usuario";
                parameters.Add(new SqlParameter("@Usuario", $"%{usuario}%"));
            }

            query += " ORDER BY Fecha DESC";

            try
            {
                using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters.ToArray()))
                {
                    while (reader.Read())
                    {
                        // Usamos el ayudante para mapear
                        lista.Add(MapToLogEntry(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                // Si la lectura de logs falla, registramos el error... ¡en el archivo!
                try { File.AppendAllText(_logFilePath, $"ERROR LEYENDO LOGS DE BD: {ex.Message}{Environment.NewLine}"); } catch { }
            }

            return lista;
        }

        // --- 3. AGREGAR ESTE MÉTODO PRIVADO DE MAPEO ---
        private LogEntry MapToLogEntry(SqlDataReader reader)
        {
            return new LogEntry
            {
                Id = Convert.ToInt32(reader["Id"]),
                Fecha = Convert.ToDateTime(reader["Fecha"]),
                Usuario = reader["Usuario"] == DBNull.Value ? null : reader["Usuario"].ToString(),
                Nivel = reader["Nivel"] == DBNull.Value ? null : reader["Nivel"].ToString(),
                Origen = reader["Origen"] == DBNull.Value ? null : reader["Origen"].ToString(),
                Mensaje = reader["Mensaje"].ToString(),
                StackTrace = reader["StackTrace"] == DBNull.Value ? null : reader["StackTrace"].ToString()
            };
        }
    }
}