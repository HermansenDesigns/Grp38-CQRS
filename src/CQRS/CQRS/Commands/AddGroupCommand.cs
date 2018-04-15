using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class AddGroupCommand : Command
    {
        public string Name { get; set; }
        public AddGroupCommand(int version, string name) : base(version)
        {
            Name = name;
        }
    }
}
