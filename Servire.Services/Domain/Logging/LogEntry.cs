using System;

namespace Servire.Services.Domain.Logging
{
    public class LogEntry
    {
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Nivel { get; set; } 
        public string Origen { get; set; } 
        public string Mensaje { get; set; }
        public string StackTrace { get; set; } 

        public LogEntry()
        {
            Fecha = DateTime.Now;
        }
    }
}