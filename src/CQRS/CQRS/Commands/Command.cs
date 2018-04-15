using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class Command : ICommand
    {
        public Command(int version)
        {
            Id = Guid.NewGuid();
            Version = version;
        }

        public Guid Id { get; private set; }
        public int Version { get; private set; }
        
    }
}
