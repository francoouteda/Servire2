using Servire.Bll.DTOs;
using System;
using System.Collections.Generic;

namespace Servire.Bll.Interfaces
{
    // ¡ESTA ES LA INTERFAZ QUE TE FALTABA!
    public interface IErrorLogService
    {
        IEnumerable<ErrorLogDto> Listar(DateTime desde, DateTime hasta);
    }
}