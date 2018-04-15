using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Query
{
    public class UserDisplay
    {
        public UserDisplay(long id, string name, DateTime age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public long Id { get; }
        public string Name { get;  }
        public DateTime Age { get;  }
    }
}
