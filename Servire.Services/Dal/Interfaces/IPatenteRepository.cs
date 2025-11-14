using System;
using Servire.Services.Domain.Composite;

namespace Servire.Services.Dal.Interfaces
{
    internal interface IPatenteRepository
    {
        Patente GetById(Guid id);
    }
}