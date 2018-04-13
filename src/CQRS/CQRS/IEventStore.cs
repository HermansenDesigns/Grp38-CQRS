using System;
using System.Collections.Generic;

namespace CQRS
{
    public interface IEventStore
    {
        void Save(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
        List<Event> Get(Guid aggregateId);
    }
}