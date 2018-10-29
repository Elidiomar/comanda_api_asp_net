using System;
using System.Collections.Generic;
using Comanda.Domain.Core.Events;

namespace Comanda.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}