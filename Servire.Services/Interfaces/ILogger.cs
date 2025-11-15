using Servire.Services.Domain.Logging;
using System;
using System.Collections.Generic;

namespace Servire.Services.Interfaces
{
    public interface ILogger
    {
        // Métodos de escritura (ya los tenías)
        void Info(string mensaje, string origen, string usuario = null);
        void Error(Exception ex, string origen, string usuario = null);
        void Log(string mensaje, string nivel = "INFO");

        // --- MÉTODO NUEVO PARA LECTURA ---
        /// <summary>
        /// Obtiene una lista de logs filtrada por fecha y usuario.
        /// </summary>
        List<LogEntry> Listar(DateTime desde, DateTime hasta, string usuario);
    }
}