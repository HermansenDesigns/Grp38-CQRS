using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public interface ICommand
    {
        Guid Id { get; }
        int Version { get; }
    }
}
