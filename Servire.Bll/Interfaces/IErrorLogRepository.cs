using Servire.Bll.DTOs;
using System;
using System.Collections.Generic;

namespace Servire.Bll.Interfaces
{
    public interface IErrorLogRepository
    {
        IEnumerable<ErrorLogDto> Listar(DateTime desde, DateTime hasta);
    }
}