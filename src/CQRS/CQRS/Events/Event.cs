using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Events
{
    
        [Serializable]
        public class Event : IEvent
        {
            public int Version;
            public Guid AggregateId { get; set; }
            public Guid Id { get; private set; }
        }
    
}
