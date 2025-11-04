using System;

namespace Servire.Bll.DTOs
{
    // Esta clase es el "molde" para los datos de la tabla ErrorLogs
    public class ErrorLogDto
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }

        public string Nivel { get; set; }  // <-- Propiedad agregada
        public string Usuario { get; set; }
        public string Fuente { get; set; }
        public string Mensaje { get; set; }
        public string Stacktrace { get; set; }
    }
}