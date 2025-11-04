namespace Servire.Bll.Interfaces;

public interface IErrorLogger
{
    void Info(string origen, string mensaje, string? usuario = null);
    void Error(string origen, Exception ex, string? usuario = null);

    
}
