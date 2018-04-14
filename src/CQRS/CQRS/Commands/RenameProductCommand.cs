using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class RenameProductCommand : Command
    {
        public readonly string ProductName;

        public RenameProductCommand(string productName, Guid id, int version) : base(id,version)
        {
            ProductName = productName;
        }
    }
}
