using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Events
{
    public class ProductRenameEvent : Event
    {
        public ProductRenameEvent(Guid aggregateID,string productName)
        {
            ProductName = productName;
            AggregateId = aggregateID; 
        }

        public string ProductName { get; internal set; }
        
    }
}
