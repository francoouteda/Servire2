using System;

namespace Servire.Services.Contracts
{
    public interface ILogger
    {
        void Log(string mensaje, string nivel = "INFO");
        void Error(Exception ex, string origen, string usuario = null);
        void Info(string mensaje, string origen, string usuario = null);
    }
}