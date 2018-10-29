using System;
using Comanda.Domain.Core.Commands;

namespace Comanda.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
