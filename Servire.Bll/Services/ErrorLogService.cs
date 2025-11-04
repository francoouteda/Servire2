using Servire.Bll.Interfaces;
using Servire.Bll.DTOs;
using System;
using System.Collections.Generic;

namespace Servire.Bll.Services
{
    public class ErrorLogService : IErrorLogService
    {
        private readonly IUnitOfWork _uow;

        public ErrorLogService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<ErrorLogDto> Listar(DateTime desde, DateTime hasta)
        {
            return _uow.ErrorLogRepository.Listar(desde, hasta);
        }
    }
}