using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Command;

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

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Age { get; set; }
        
    }
}
