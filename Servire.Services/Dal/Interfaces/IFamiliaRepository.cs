using System;
using Servire.Services.Domain.Composite;

namespace Servire.Services.Dal.Interfaces
{
    internal interface IFamiliaRepository
    {
        Familia GetById(Guid id);
    }
}