using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class AddUserCommand : Command
    {
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public AddUserCommand(int version, DateTime age, string name) : base(version)
        {
            Age = age;
            Name = name;
        }
    }
}
