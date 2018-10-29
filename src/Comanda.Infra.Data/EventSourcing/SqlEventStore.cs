using Comanda.Domain.Core.Events;
using Comanda.Domain.Interfaces;
using Comanda.Infra.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace Comanda.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly ICurrentUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, ICurrentUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Name);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}