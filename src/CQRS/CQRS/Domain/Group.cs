using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain
{
    public class Group
    {
        public virtual List<User> Members { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public long Id { get; set; }
    }
}
